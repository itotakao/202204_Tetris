using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class I_Tetorimino : TetoriminoBase
{
    public I_Tetorimino()
    {
        this.color = Color.red;
        this.data = new int[,]{
            {0,0,0,0 },
            {1,1,1,1 },
            {0,0,0,0 },
            {0,0,0,0 }
        };
        //this.data = new int[,]{
        //    {0,0,0,0 },
        //    {0,1,1,0 },
        //    {0,1,1,0 },
        //    {0,0,0,0 }
        //};
    }

    public override void rotationLeft()
    {
        // Do Nothing
    }

    public override void rotationRight()
    {
        var copyData = new int[data.GetLength(0),data.GetLength(1)];
        Array.Copy(data, copyData, data.Length);

        var a = new List<List<int>>();
        var b = new List<int>();

        var txt = "";
        for (int i = 0; i < data.GetLength(0); i++)
        {
            for (int j = 0; j < data.GetLength(1); j++)
            {
                //Debug.Log(data[data.GetLength(1) - 1 - j, i]);
                //a.Add((i,data[data.GetLength(1) - 1 - j, i]));
                //b.Add(data[data.GetLength(1) - 1 - j, i]);
                data[j, i] = copyData[data.GetLength(1) - 1 - j, i];

                txt += data[data.GetLength(1) - 1 - j,i];
            }
            //a.Add(b);
            //b.Clear();
            txt += "\n";
        }
        //data = new int[,]
        //{
        //    { a[0][0],a[0][1],a[0][2],a[0][3] },
        //    { a[1][0],a[1][1],a[1][2],a[1][3] },
        //    { a[2][0],a[2][1],a[2][2],a[2][3] },
        //    { a[3][0],a[3][1],a[3][2],a[3][3] }
        //};
        Debug.Log(txt);
    }
}
