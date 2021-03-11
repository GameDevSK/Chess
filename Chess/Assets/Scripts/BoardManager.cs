using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public static BoardManager Instance;
    public bool[,] allowedMovesForSelectedChessman;

    public Chessman[,] chessmans;
    private List<GameObject> activeChessmans= new List<GameObject>();

    private int selectionX = -1;
    private int selectionY = -1;

    //ScriptableObject
    public Board board;

    //Contains all chess pieces' prefabs
    public GameObject[] chessmanPrefabs;
    [Space(20)]

    //Highlight gameobject
    public GameObject highlight;

    GameObject selectedChessmanPiece;
    Chessman selectedChessman;

    bool isWhiteTurn = true;

    void Start()
    {
        Instance = this;
        board.GenerateBoardGraphics();
        SpawnAllChessman();
    }

    void Update()
    {
        if (selectedChessmanPiece != null)
        {
            selectedChessman = selectedChessmanPiece.GetComponent<Chessman>();
            MovementOfChessPieces(selectedChessmanPiece, selectionX, selectionY);
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            selectedChessmanPiece = SelectChessPiece();
        }
    }

    private void MovementOfChessPieces(GameObject selectedPiece, int x, int y)
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = GetMousePosition();
            mousePos.z = 10f;
            RaycastHit2D hit = GetHitInfo(mousePos, LayerMask.GetMask("Highlight"));

            if(hit.collider != null)
            {
                Vector3 hitPos = hit.collider.transform.position;
                x = (int)hitPos.x;
                y = (int)hitPos.y;

                
                Chessman c = chessmans[x, y];

                if (allowedMovesForSelectedChessman[x, y])
                {
                    chessmans[selectedChessman.CurrentX, selectedChessman.CurrentY] = null;

                    selectedChessman.transform.position = hitPos;

                    if (c != null && c.isWhite != isWhiteTurn)
                    {
                        if(c.GetType() == typeof(King))
                        {
                            EndGame();
                            return;
                        }
                        activeChessmans.Remove(c.gameObject);
                        Destroy(c.gameObject);
                    }
                    HighlightsManager.Instance.HideHighlights();
                    RemoveAllPrevoiusHighlights();

                    chessmans[x, y] = selectedChessman;
                    selectedChessman.SetPosition(x, y);
                    isWhiteTurn = !isWhiteTurn;
                }
                selectedChessman.isSelected = false;
                selectedChessman = null;
            }   
        }   
    }

    private void EndGame()
    {
    }

    //This function will remove all previous highlights
    private void RemoveAllPrevoiusHighlights()
    {
        GameObject[] allHighlights = GameObject.FindGameObjectsWithTag("Highlight");
        if(allHighlights.Length != 0)
        {
            foreach (GameObject obj in allHighlights)
                Destroy(obj);
        }
    }

    //method contains all chess pieces together
    void SpawnAllChessman()
    {
        chessmans = new Chessman[8, 8];
        //Whites
        //King
        SpawnPiece(0,new Vector2(4f,0f));

        //Queen
        SpawnPiece(1, new Vector2(3f, 0f));

        //Rook
        SpawnPiece(2, new Vector2(0f, 0f));
        SpawnPiece(2, new Vector2(7f, 0f));

        //Bishop
        SpawnPiece(3, new Vector2(2f, 0f));
        SpawnPiece(3, new Vector2(5f, 0f));

        //Knight
        SpawnPiece(4, new Vector2(1f, 0f));
        SpawnPiece(4, new Vector2(6f, 0f));

        //Pawn
        SpawnPiece(5, new Vector2(0f, 1f));
        SpawnPiece(5, new Vector2(1f, 1f));
        SpawnPiece(5, new Vector2(2f, 1f));
        SpawnPiece(5, new Vector2(3f, 1f));
        SpawnPiece(5, new Vector2(4f, 1f));
        SpawnPiece(5, new Vector2(5f, 1f));
        SpawnPiece(5, new Vector2(6f, 1f));
        SpawnPiece(5, new Vector2(7f, 1f));


        //Blacks
        //King
        SpawnPiece(6, new Vector2(4f, 7f));

        //Queen
        SpawnPiece(7, new Vector2(3f, 7f));

        //Rook
        SpawnPiece(8, new Vector2(0f, 7f));
        SpawnPiece(8, new Vector2(7f, 7f));

        //Bishop
        SpawnPiece(9, new Vector2(2f, 7f));
        SpawnPiece(9, new Vector2(5f, 7f));

        //Knight
        SpawnPiece(10, new Vector2(1f, 7f));
        SpawnPiece(10, new Vector2(6f, 7f));

        //Pawn
        SpawnPiece(11, new Vector2(0f, 6f));
        SpawnPiece(11, new Vector2(1f, 6f));
        SpawnPiece(11, new Vector2(2f, 6f));
        SpawnPiece(11, new Vector2(3f, 6f));
        SpawnPiece(11, new Vector2(4f, 6f));
        SpawnPiece(11, new Vector2(5f, 6f));
        SpawnPiece(11, new Vector2(6f, 6f));
        SpawnPiece(11, new Vector2(7f, 6f));
    }

    //Spawn all pieces
    void SpawnPiece(int index, Vector2 position)
    {
        int x = (int)position.x;
        int y = (int)position.y;

        GameObject go = Instantiate(chessmanPrefabs[index], position,Quaternion.identity);

        chessmans[x, y] = go.GetComponent<Chessman>();
        chessmans[x, y].SetPosition(x, y);

        activeChessmans.Add(go);
        go.transform.SetParent(GameObject.Find("ChessPieces").transform);
    }

    //return chessPiecePosition
    GameObject SelectChessPiece()
    {
        Vector3 mousePos = GetMousePosition();
        mousePos.z = 10f;

        RaycastHit2D hit = GetHitInfo(mousePos, LayerMask.GetMask("Chessman"));
        if (hit)
        {
            selectedChessman = hit.collider.gameObject.GetComponent<Chessman>();

            if (selectedChessman.isWhite != isWhiteTurn)
                return null;

            selectedChessmanPiece = hit.collider.gameObject;

            selectionX = (int)selectedChessmanPiece.transform.localPosition.x;
            selectionY = (int)selectedChessmanPiece.transform.localPosition.y;

            HighlightsManager.Instance.HideHighlights();
            allowedMovesForSelectedChessman = chessmans[selectionX, selectionY].PossibleMove();

            bool hasAtleastOneMove = false;
            for(int i=0; i<8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if(allowedMovesForSelectedChessman[i,j])
                    {
                        hasAtleastOneMove = true;
                        break;
                    }
                }
            }
            if (!hasAtleastOneMove)
                return null;

            HighlightsManager.Instance.InstatiateHighlightsForAllowedMoves(allowedMovesForSelectedChessman);

            selectedChessman.isSelected = true;

            
            RemoveAllPrevoiusHighlights();
            Instantiate(highlight, selectedChessmanPiece.transform.position, Quaternion.identity);
            return selectedChessmanPiece;
        }
        return null;
    }

    //to get current mouse position
    private  Vector3 GetMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    RaycastHit2D GetHitInfo(Vector3 mousePos, LayerMask mask)
    {
        return Physics2D.Raycast(new Vector2(mousePos.x, mousePos.y), Vector2.zero, 25f, mask);
    }

}
