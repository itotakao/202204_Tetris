using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleStartButton : MonoBehaviour
{
    GameManager GameManager => GameManager.Current;

    public void OnPressedButton()
    {
        GameManager.SwitchScene(SceneType.Game);
    }
}
