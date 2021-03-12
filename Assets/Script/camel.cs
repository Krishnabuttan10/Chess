using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camel : chessman
{
    public override bool[,] posibleMove()
    {
        bool[,] r = new bool[8, 8];
        chessman c;
        int i, j;
        //top left
        i = CurrentX;
        j = CurrentY;
        while (true)
        {
            i--;
            j++;
            if (i < 0 || j >= 8)
                break;
            c = chessboardmanager.Instance.chessmans[i, j];
            if (c == null)
            {
                r[i, j] = true;
            }
            else
            {
                if (c.iswhite != iswhite)
                {
                    r[i, j] = true;

                }
                break;
            }
        }
        //top right
        i = CurrentX;
        j = CurrentY;
        while (true)
        {
            i++;
            j++;
            if (i >= 8 || j >= 8)
                break;
            c = chessboardmanager.Instance.chessmans[i, j];
            if (c == null)
            {
                r[i, j] = true;
            }
            else
            {
                if (c.iswhite != iswhite)
                {
                    r[i, j] = true;

                }
                break;
            }
        }
        //bottom left
        i = CurrentX;
        j = CurrentY;
        while (true)
        {
            i--;
            j--;
            if (i < 0 || j < 0)
            {
                break;
            }

            c = chessboardmanager.Instance.chessmans[i, j];
            if (c == null)
            {
                r[i, j] = true;
            }
            else
            {
                if (c.iswhite != iswhite)
                {
                    r[i, j] = true;

                }
                break;
            }
        }

        //bottom right
        i = CurrentX;
        j = CurrentY;
        while (true)
        {
            i++;
            j--;
            if (i >= 8  || j < 0)
                break;
            c = chessboardmanager.Instance.chessmans[i, j];
            if (c == null)
            {
                r[i, j] = true;
            }
            else
            {
                if (c.iswhite != iswhite)
                {
                    r[i, j] = true;

                }
                break;
            }
        }
        return r;
    }
}
