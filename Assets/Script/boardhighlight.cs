using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boardhighlight : MonoBehaviour
{
    public static boardhighlight Instance { set; get; }
    public GameObject highlightprefab;
    //public bool ; 
    List<GameObject> highlights;
    private void Start()
    {
        Instance = this;
        highlights = new List<GameObject>();
    }

    GameObject highlightobj()
    {
        GameObject go = highlights.Find(g => g.activeSelf);
        if (go == null)
        {
            go = Instantiate(highlightprefab);
            highlights.Add(go);

        }

        return go;
    }

    public void highlightallowedmovs(bool[,] moves)
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (moves[i, j] == true)
                {
                    GameObject go = highlightobj();
                    go.SetActive(true);
                    go.transform.position = new Vector3(i+.5f, -0.35f, j+.5f);
                }
            }
        }
    }

    public void hidehighligt()
    {
        foreach (GameObject go in highlights)
            go.SetActive(false);
    }
}
