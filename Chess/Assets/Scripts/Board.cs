using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Board", menuName = "Create/board")]
public class Board : ScriptableObject
{
    public Sprite sprite;


    public Color lightColor;
    public Color darkColor;

    GameObject board;

    GameObject chessBoardSqaures;
    GameObject chessPieces;
    public void GenerateBoardGraphics()
    {
        board = new GameObject("Board");
        board.transform.position = new Vector2(0, 0);

        chessBoardSqaures = new GameObject("ChessBoardSqaures");
        SetParent(chessBoardSqaures, board);

        for (int row = 0; row < 8; row++)
        {
            for (int column = 0; column < 8; column++)
            {
                bool isLightSqaure = (row + column) % 2 == 0;

                Color squareColor = (isLightSqaure) ? lightColor : darkColor;
                Vector2 position = new Vector2(column, row);

                DrawSqaure(squareColor, position);
            }
        }
        chessPieces = new GameObject("ChessPieces");
        SetParent(chessPieces, board);
        
    }

    private void SetParent(GameObject child, GameObject parent)
    {
        child.transform.SetParent(parent.transform);
    }


    void DrawSqaure(Color sqaureColor, Vector2 pos)
    {
        GameObject go = new GameObject(pos.ToString());
        if (go.GetComponent<SpriteRenderer>() == null)
        {
            SpriteRenderer renderer = go.AddComponent<SpriteRenderer>();
            renderer.sortingOrder = -1;
            renderer.sprite = sprite;
            renderer.color = sqaureColor;
        }
        go.transform.position = pos;
        go.AddComponent<BoxCollider2D>();
        go.transform.SetParent(chessBoardSqaures.transform);
    }
}
