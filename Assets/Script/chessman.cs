using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chessman : MonoBehaviour
{
    public int CurrentX { set; get; }
    public int CurrentY { set; get; }
    public bool iswhite;

    public void SetPos(int x, int y)
    {
        CurrentX = x;
        Debug.Log("x" + CurrentX);
        CurrentY = y;
        Debug.Log("y" + CurrentY);
    }

   /* public virtual bool posiblemove(int x, int y)
    {
        Debug.Log("true");
        return true;
    }*/
    public virtual bool[,] posibleMove()
    {
        Debug.Log("true");
        return new bool[8, 8];

    }
}
