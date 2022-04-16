using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Current;

    [SerializeField]
    private SceneType currentSceneType = SceneType.None;

    [SerializeField]
    private GameObject titleRoot;
    [SerializeField]
    private GameObject gameRoot;
    [SerializeField]
    private GameObject resultRoot;

    private void Awake()
    {
        Current = this;
    }

    public void SwitchScene(SceneType sceneType)
    {
        currentSceneType = sceneType;

        titleRoot.SetActive(false);
        gameObject.SetActive(false);
        resultRoot.SetActive(false);

        switch (sceneType)
        {
            case SceneType.None:
                throw new System.ComponentModel.InvalidEnumArgumentException();
            case SceneType.Title:
                titleRoot.SetActive(true);
                break;
            case SceneType.Game:
                gameObject.SetActive(true);
                break;
            case SceneType.Result:
                resultRoot.SetActive(true);
                break;
            default:
                throw new System.ComponentModel.InvalidEnumArgumentException();
        }
    }
}
