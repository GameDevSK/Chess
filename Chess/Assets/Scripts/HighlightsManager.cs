using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightsManager : MonoBehaviour
{
    public static HighlightsManager Instance;

    public GameObject highlightPrefab;
    private List<GameObject> allHighlights;
    private void Awake()
    {
        Instance = this;
        allHighlights = new List<GameObject>();
    }

    public void InstatiateHighlightsForAllowedMoves(bool[,] moves)
    {
        for(int i = 0; i < 8; i++)
        {
            for(int j=0; j<8; j++)
            {
                if (moves[i, j])
                {
                    GameObject go = Instantiate(highlightPrefab) as GameObject;
                    go.transform.position = new Vector3(i, j);
                    allHighlights.Add(go);
                }
            }
        }
    }
    public void HideHighlights()
    {
        foreach (GameObject go in allHighlights)
            Destroy(go);
    }
}
