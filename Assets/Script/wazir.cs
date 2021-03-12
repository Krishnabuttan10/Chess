using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wazir : chessman
{
    public override bool[,] posibleMove()
    {
        bool[,] r = new bool[8, 8];
        chessman c;
        int i, j;
        i = CurrentX;
        while (true)
        {
            i++;
            if (i >= 8)     //Move right
                break;

            c = chessboardmanager.Instance.chessmans[i, CurrentY];

            if (c == null)
            {
                r[i, CurrentY] = true;
            }
            else
            {
                if (c.iswhite != iswhite)
                    r[i, CurrentY] = true;

                break;
            }
        }
        //        LEFT

        i = CurrentX;           //------------currentX= width (x axis)
        while (true)
        {
            i--;
            if (i < 0)
                break;

            c = chessboardmanager.Instance.chessmans[i, CurrentY];

            if (c == null)
            {
                r[i, CurrentY] = true;
            }
            else
            {
                if (c.iswhite != iswhite)
                    r[i, CurrentY] = true;

                break;
            }
        }
        //      UP----------
        i = CurrentY;
        while (true)                //---------currentY = Depth (z axis)
        {
            i++;
            if (i >= 8)
                break;

            c = chessboardmanager.Instance.chessmans[CurrentX, i];

            if (c == null)
            {
                r[CurrentX, i] = true;
            }
            else
            {

                if (c.iswhite != iswhite)
                {
                    r[CurrentX, i] = true;
                }
                break;
            }
        }

        //          Down
        i = CurrentY;
        while (true)
        {
            i--;
            if (i < 0)
                break;

            c = chessboardmanager.Instance.chessmans[CurrentX, i];

            if (c == null)
            {
                r[CurrentX, i] = true;
            }
            else
            {
                if (c.iswhite != iswhite)
                    r[CurrentX, i] = true;

                break;
            }
        }

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

        //bottom right
        i = CurrentX;
        j = CurrentY;
        while (true)
        {
            i++;
            j--;
            if (i >= 8 || j < 0)
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
