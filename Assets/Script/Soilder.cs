using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soilder : chessman
{
    public override bool[,] posibleMove()
    {
        bool[,] r = new bool[8, 8];
        // r[3, 3] =true;
        int[] e = chessboardmanager.Instance.EnpassantMove;
        chessman c, c2;
        if (iswhite)    //--------------White-
        {
            Debug.Log("currentX =" + CurrentX + "\t Current Y = " + CurrentY);
            if (CurrentX != 0 && CurrentY != 7)    //Daigonal Left-----------------
            {
                if (e[0] == CurrentX - 1 && e[1] == CurrentY + 1)
                {
                    r[CurrentX - 1, CurrentY + 1] = true;
                }
                c = chessboardmanager.Instance.chessmans[CurrentX - 1, CurrentY + 1];
                if (c != null && !c.iswhite)
                { r[CurrentX - 1, CurrentY + 1] = true; }
            }

            if (CurrentX != 7 && CurrentY != 7)  //Diagonal rIGHT-------------------
            {
                if (e[0] == CurrentX + 1 && e[1] == CurrentY + 1)
                {
                    r[CurrentX + 1, CurrentY + 1] = true;
                }
                c = chessboardmanager.Instance.chessmans[CurrentX + 1, CurrentY + 1];
                if (c != null && !c.iswhite)
                {
                    r[CurrentX + 1, CurrentY + 1] = true;
                }
            }

            if (CurrentY != 7)         //--------Middle--------------
            {
                if (e[0] == CurrentX - 1 && e[1] == CurrentY + 1)
                {
                    r[CurrentX - 1, CurrentY + 1] = true;
                }
                c = chessboardmanager.Instance.chessmans[CurrentX, CurrentY + 1];
                if (c == null)
                {
                    r[CurrentX, CurrentY + 1] = true;
                }
            }

            if (CurrentY == 1)  //Middle -> first move-----------
            {
                c = chessboardmanager.Instance.chessmans[CurrentX, CurrentY + 1];
                c2 = chessboardmanager.Instance.chessmans[CurrentX, CurrentY + 2];

                if (c == null && c2 == null)
                {
                    r[CurrentX, CurrentY + 2] = true;
                }
            }


        }
        else //-------------black----------------------
        {
            Debug.Log("currentX =" + CurrentX + "\t Current Y = " + CurrentY);
            if (CurrentX != 0 && CurrentY != 0)    //Daigonal Left-----------------
            {
                if (e[0] == CurrentX - 1 && e[1] == CurrentY - 1)
                {
                    r[CurrentX - 1, CurrentY - 1] = true;
                }
                c = chessboardmanager.Instance.chessmans[CurrentX - 1, CurrentY - 1];
                if (c != null && c.iswhite)
                { r[CurrentX - 1, CurrentY - 1] = true; }
            }

            if (CurrentX != 7 && CurrentY != 0)  //Diagonal rIGHT-------------------
            {
                if (e[0] == CurrentX + 1 && e[1] == CurrentY + 1)
                {
                    r[CurrentX - 1, CurrentY + 1] = true;
                }
                c = chessboardmanager.Instance.chessmans[CurrentX + 1, CurrentY - 1];
                if (c != null && c.iswhite)
                {
                    r[CurrentX + 1, CurrentY - 1] = true;
                }
            }

            if (CurrentY != 0)         //--------Middle--------------
            {
                c = chessboardmanager.Instance.chessmans[CurrentX, CurrentY - 1];
                if (c == null)
                {
                    r[CurrentX, CurrentY -1] = true;
                }
            }

            if (CurrentY == 6)  //Middle first move-----------
            {
                c = chessboardmanager.Instance.chessmans[CurrentX, CurrentY - 1];
                c2 = chessboardmanager.Instance.chessmans[CurrentX, CurrentY - 2];

                if (c == null && c2 == null)
                {
                    r[CurrentX, CurrentY - 2] = true;
                }
            }
        }
        
        return r;
       

    }
}
