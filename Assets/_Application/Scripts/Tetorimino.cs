using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UniRx;
using UniRx.Triggers;

public class Tetorimino : MonoBehaviour
{
    private GameLauncuer GameLauncuer => GameLauncuer.Current;

    public bool IsDown = true;

    public int[][,] TetriminoData = new int[][,]
    {
        new int[,] {
            {0,0,0,0 },
            {1,1,1,1 },
            {0,0,0,0 },
            {0,0,0,0 }
        },
        new int[,] {
            {0,0,0,0 },
            {0,1,1,0 },
            {0,1,1,0 },
            {0,0,0,0 }
        },
        new int[,] {
            {0,0,0,0 },
            {0,1,1,0 },
            {0,0,1,1 },
            {0,0,0,0 }
        },
        new int[,] {
            {1,0,0,0 },
            {1,1,1,1 },
            {0,0,0,0 },
            {0,0,0,0 }
        },
        new int[,] {
            {0,0,0,0 },
            {0,0,0,0 },
            {0,0,0,0 },
            {0,0,0,0 }
        },
        new int[,] {
            {0,0,0,0 },
            {0,0,0,0 },
            {0,0,0,0 },
            {0,0,0,0 }
        },
        new int[,] {
            {0,0,0,0 },
            {0,0,0,0 },
            {0,0,0,0 },
            {0,0,0,0 }
        }
    };

    private readonly Vector3 horizontalLate = new Vector3(1, 0, 0);
    private readonly Vector3 verticalLate = new Vector3(0, 1, 0);

    private IDisposable leftMoveDisposable;
    private IDisposable rightMoveDisposable;

    private async void Start()
    {
        leftMoveDisposable = this.UpdateAsObservable()
            .Where(_ => Input.GetKeyDown(KeyCode.A))
            .Subscribe(_ => MoveLeft())
            .AddTo(this);

        rightMoveDisposable = this.UpdateAsObservable()
            .Where(_ => Input.GetKeyDown(KeyCode.D))
            .Subscribe(_ => MoveRight())
            .AddTo(this);

        var a = TetriminoData[0][0, 1];

        var mino = new I_Tetorimino();

        while (true)
        {
            await Task.Delay(1000);

            bool isCheckHoge = CheckHogehoge();
            if (isCheckHoge)
            {
                break;
            }

            mino.rotationRight();
            MoveDown();
        }

        OnComplete();
    }

    private bool CheckHogehoge()
    {
        var y = (int)transform.localPosition.x;
        var x = Math.Abs((int)transform.localPosition.y);
        //Debug.Log(x + "   " + y);

        var data = GameLauncuer.FieldData[x + 1, 6];
        var isEnd = (data == 1);
        return isEnd;
    }

    private void MoveLeft()
    {
        transform.position -= horizontalLate;
    }

    private void MoveRight()
    {
        transform.position += horizontalLate;
    }

    private void MoveDown()
    {
        transform.position -= verticalLate;
    }

    private void OnComplete()
    {
        IsDown = false;
        leftMoveDisposable.Dispose();
        rightMoveDisposable.Dispose();
    }
}
