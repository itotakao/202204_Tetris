using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

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

    [SerializeField]
    private GameObject tetorimino;

    [SerializeField]
    private ScriptGraphAsset scriptGraph;

    private void Awake()
    {
        Current = this;

        StartCoroutine(CoUpdate());

        SwitchScene(SceneType.Title);
    }

    private IEnumerator CoUpdate()
    {
        while (true)
        {
            yield return new WaitUntil(() => (currentSceneType == SceneType.Game));

            var obj = Instantiate(tetorimino, new Vector3(0, 21, 0), Quaternion.identity);
            obj.SetActive(true);
            Variables.Object(obj).Set("IsDown", true);

            yield return new WaitForSeconds(21);
        }
    }


    public void SwitchScene(SceneType sceneType)
    {
        currentSceneType = sceneType;

        titleRoot.SetActive(false);
        gameRoot.SetActive(false);
        resultRoot.SetActive(false);

        switch (sceneType)
        {
            case SceneType.None:
                throw new System.ComponentModel.InvalidEnumArgumentException();
            case SceneType.Title:
                titleRoot.SetActive(true);
                break;
            case SceneType.Game:
                gameRoot.SetActive(true);
                break;
            case SceneType.Result:
                resultRoot.SetActive(true);
                break;
            default:
                throw new System.ComponentModel.InvalidEnumArgumentException();
        }
    }
}
