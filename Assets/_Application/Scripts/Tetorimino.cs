using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UniRx;
using UniRx.Triggers;

public class Tetorimino : MonoBehaviour
{
    private readonly Vector3 horizontalLate = new Vector3(1, 0, 0);
    private readonly Vector3 verticalLate = new Vector3(0, 1, 0);

    private async void Start()
    {
        this.UpdateAsObservable()
            .Where(_ => Input.GetKeyDown(KeyCode.A))
            .Subscribe(_ => MoveLeft())
            .AddTo(this);

        this.UpdateAsObservable()
            .Where(_ => Input.GetKeyDown(KeyCode.D))
            .Subscribe(_ => MoveRight())
            .AddTo(this);

        while (true)
        {
            bool isCheckHoge = CheckHogehoge();
            if (isCheckHoge)
            {
                break;
            }

            await Task.Delay(1000);

            MoveDown();
        }
    }

    private bool CheckHogehoge()
    {
        return false;
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
}
