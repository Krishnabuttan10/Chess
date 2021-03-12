using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chessboardmanager : MonoBehaviour
{
    public static chessboardmanager Instance { set; get; }
    public bool[,] allowedmove { set; get; }

    Material previousmat;
    public Material selectmat;
    public Camera cam;
    const float TileSize = 1.0f;
    const float TileOffset = 0.5f;

    public int[] EnpassantMove { set; get; }
    int SelectionX = -1;
    int SelectionY = -1;
    Quaternion orientation = Quaternion.Euler(0f, 180f, 0f);

    public List<GameObject> chessmanprefab;
    List<GameObject> activeChessman;
    public chessman[,] chessmans { set; get; }
    private chessman selectedchessman;
    public bool iswhiteturn = true;

    private void Start()
    {
        Instance = this;
        SpawnAll();
    }
    private void Update()
    {
        UpdateSelection();
        DrawChessBoard();
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Button Pressed");
            if (SelectionX >= 0 && SelectionY >= 0)
            {
                if (selectedchessman == null)
                {
                    Debug.Log("Selected" + selectedchessman);
                    Debug.Log("Selection..");
                    SelectChessman(SelectionX, SelectionY);
                    //select
                }
                else
                {
                    //move
                    Debug.Log("moved");

                    Movechessman(SelectionX, SelectionY);
                }
            }
        }
    }

    void Movechessman(int x, int y)
    {
        if (allowedmove[x, y] == true)
        {
            chessman c = chessmans[x, y];
            if (c != null && c.iswhite != iswhiteturn)
            {
                if (c.GetType() == typeof(king))
                {
                    endgame();
                    return;
                }
                //capture the piece 
                activeChessman.Remove(c.gameObject);
                Destroy(c.gameObject);
                Debug.Log("Destroyed..." + c.gameObject);
            }
            if (x == EnpassantMove[0] && y == EnpassantMove[1])
            {
                if (iswhiteturn)
                    c = chessmans[x, y];
                else
                    c = chessmans[x, y];
            }
            EnpassantMove[0] = -1;
            EnpassantMove[1] = -1;
            if (selectedchessman.GetType() == typeof(Soilder))
            {
                if (y == 7)
                {
                    activeChessman.Remove(selectedchessman.gameObject);
                    Destroy(selectedchessman.gameObject);

                    SpawnChessman(1, x, y);
                    selectedchessman = chessmans[x, y];
                }
                else if (y == 0)
                {
                    activeChessman.Remove(selectedchessman.gameObject);
                    Destroy(selectedchessman.gameObject);
                    SpawnChessman(7, x, y);
                    selectedchessman = chessmans[x, y];
                }
                if (selectedchessman.CurrentY == 1 && y == 3)
                {
                    EnpassantMove[0] = x;
                    EnpassantMove[1] = y - 1;
                }
                else if (selectedchessman.CurrentY == 6 && y == 4)
                {
                    EnpassantMove[0] = x;
                    EnpassantMove[1] = y + 1;
                }
            }
            chessmans[selectedchessman.CurrentX, selectedchessman.CurrentY] = null;
            selectedchessman.transform.position = TileCentre(x, y);
            selectedchessman.SetPos(x, y);
            chessmans[x, y] = selectedchessman;
            iswhiteturn = !iswhiteturn;

        }
        selectedchessman.GetComponent<MeshRenderer>().material = previousmat;
        //  boardhighlight.Instance.hidehighligt();
        selectedchessman = null;
    }
    void endgame()
    {
        if (iswhiteturn)
            Debug.Log("white team win");
        else
            Debug.Log("Black team win");
        foreach (GameObject go in activeChessman)
            Destroy(go);
        iswhiteturn = true;
        SpawnAll();
    }
    void SelectChessman(int x, int y)
    {
        if (chessmans[x, y] == null)
        {
            Debug.Log("select the chessman");
            return;
        }


        if (chessmans[x, y].iswhite != iswhiteturn)
            return;
        bool hasatleastmove = false;

        allowedmove = chessmans[x, y].posibleMove();
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (allowedmove[i, j] == true)
                    hasatleastmove = true;
            }
        }
        if (!hasatleastmove)
            return;

        selectedchessman = chessmans[x, y];
        previousmat = selectedchessman.GetComponent<MeshRenderer>().material;
        selectmat.mainTexture = previousmat.mainTexture;
        selectedchessman.GetComponent<MeshRenderer>().material = selectmat;


        //  boardhighlight.Instance.highlightallowedmovs(allowedmove);

    }
    void DrawChessBoard()
    {
        Vector3 Width = Vector3.right * 8;
        Vector3 Depth = Vector3.forward * 8;

        for (int i = 0; i <= 8; i++)
        {
            Vector3 start = Vector3.forward * i;
            Debug.DrawLine(start, start + Width);
            for (int j = 0; j <= 8; j++)
            {
                start = Vector3.right * j;
                Debug.DrawLine(start, start + Depth);
            }
        }

        if (SelectionX >= 0 && SelectionY >= 0)
        {
            Debug.DrawLine(Vector3.forward * SelectionY + Vector3.right * SelectionX, Vector3.forward * (SelectionY + 1) + Vector3.right * (SelectionX));
        }
    }

    void UpdateSelection()
    {
        if (!Camera.main)
            return;

        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 50.0f, LayerMask.GetMask("chessboardplane")))
        {
            // Debug.Log(hit.point);
            Debug.DrawRay(cam.transform.position, transform.TransformDirection(Vector3.forward) * 10f, Color.red);
            SelectionX = (int)hit.point.x;

            SelectionY = (int)hit.point.z;
            Debug.Log("SElection x " + SelectionX + "Selection y " + SelectionY);
        }
        else
        {
            SelectionX = -1;
            SelectionY = -1;
        }
    }

    Vector3 TileCentre(int x, int y)
    {
        Vector3 origin = Vector3.zero;
        origin.x += (TileSize * x) + TileOffset;
        origin.z += (TileSize * y) + TileOffset;
        return origin;
    }

    void SpawnAll()
    {
        activeChessman = new List<GameObject>();
        chessmans = new chessman[8, 8];
        EnpassantMove = new int[2] { -1, -1 };
        //--------------------white-------------------
        //--king---
        SpawnChessman(0, 3, 0);
        //--wazir---
        SpawnChessman(1, 4, 0);
        //--elephant---
        SpawnChessman(2, 0, 0);
        SpawnChessman(2, 7, 0);
        //--camel---
        SpawnChessman(3, 2, 0);
        SpawnChessman(3, 5, 0);
        //--kinght/horse
        SpawnChessman(4, 1, 0);
        SpawnChessman(4, 6, 0);
        //--soilder---
        for (int i = 0; i < 8; i++)
        {
            SpawnChessman(5, i, 1);
        }
        //--------------------black--------------
        //--king---
        SpawnChessman(6, 4, 7);
        //--wazir---
        SpawnChessman(7, 3, 7);
        //--elephant---
        SpawnChessman(8, 0, 7);
        SpawnChessman(8, 7, 7);
        //--camel---
        SpawnChessman(9, 2, 7);
        SpawnChessman(9, 5, 7);
        //--kinght/horse---
        SpawnChessman(10, 1, 7);
        SpawnChessman(10, 6, 7);
        //--soilder---
        for (int i = 0; i < 8; i++)
        {
            SpawnChessman(11, i, 6);
        }

    }
    void SpawnChessman(int index, int x, int y)
    {
        GameObject go = Instantiate(chessmanprefab[index], TileCentre(x, y), orientation) as GameObject;
        go.transform.SetParent(transform);
        chessmans[x, y] = go.GetComponent<chessman>();
        chessmans[x, y].SetPos(x, y);
        Debug.Log("abc" + chessmans[x, y]);
        activeChessman.Add(go);
    }
}
