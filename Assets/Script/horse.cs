using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class horse : chessman
{
    public override bool[,] posibleMove()
    {
        bool[,] r = new bool[8, 8];       

        horsemove(CurrentX - 1, CurrentY + 2,ref r);// up left
        horsemove(CurrentX +1, CurrentY + 2, ref r);//up right
        horsemove(CurrentX + 2, CurrentY +1 , ref r);//right up
        horsemove(CurrentX +2, CurrentY - 1, ref r); //right down

        horsemove(CurrentX - 1, CurrentY - 2, ref r);// down left
        horsemove(CurrentX + 1, CurrentY - 2, ref r);//down right
        horsemove(CurrentX - 2, CurrentY + 1, ref r);//leftup
        horsemove(CurrentX - 2, CurrentY - 1, ref r); //left down
        return r;
    }

    public void horsemove(int x, int y, ref bool[,] r)
    {
        chessman c;
        if (x >= 0 && x < 8 && y >= 0 && y < 8)
        {
            c = chessboardmanager.Instance.chessmans[x, y];
            if (c == null)
                r[x, y] = true;

            else if (c.iswhite != iswhite)
                r[x, y] = true;
        }
    }
}
