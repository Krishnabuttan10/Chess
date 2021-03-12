using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class king : chessman
{
    public override bool[,] posibleMove()
    {
        bool[,] r = new bool[8, 8];
        chessman c;

        //top side
        int i, j;
        i = CurrentX - 1;
        j = CurrentY + 1;

        if (CurrentY != 7)
        {
            for (int k = 0; k < 3; k++)
            {
                if (i >= 0 || i < 8)
                {
                    c = chessboardmanager.Instance.chessmans[i, j];
                    if (c == null)
                        r[i, j] = true;
                    else if (c.iswhite != iswhite)
                        r[i, j] = true;

                }
                i++;
            }
        }

        //Down side

        i = CurrentX - 1;
        j = CurrentY - 1;

        if (CurrentY != 0)
        {
            for (int k = 0; k < 3; k++)
            {
                if (i > 0 || i < 8)
                {
                    c = chessboardmanager.Instance.chessmans[i, j];
                    if (c == null)
                        r[i, j] = true;
                    else if (c.iswhite != iswhite)
                        r[i, j] = true;

                }
                i++;
            }
        }

        //middle left

        if (CurrentX != 0)
        {
            c = chessboardmanager.Instance.chessmans[CurrentX - 1, CurrentY];
            if (c == null)
                r[CurrentX - 1, CurrentY] = true;
            else if (c.iswhite != iswhite)
                r[CurrentX - 1, CurrentY] = true;          
        }

        // middle right

        if (CurrentX != 7)
        {
            c = chessboardmanager.Instance.chessmans[CurrentX + 1, CurrentY];
            if (c == null)
                r[CurrentX + 1, CurrentY] = true;
            else if (c.iswhite != iswhite)
                r[CurrentX + 1, CurrentY] = true;
        }

        return r;
    }
}
