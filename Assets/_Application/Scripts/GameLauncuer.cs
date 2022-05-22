using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class GameLauncuer : MonoBehaviour
{
    public static GameLauncuer Current { get; private set; }

    public int[,] FieldData = new int[,] {
        { 0,0,0,0,0,0,0,0,0,0,0,0 },
        { 1,1,1,0,0,0,0,0,0,1,1,1 },
        { 1,0,0,0,0,0,0,0,0,0,0,1 },
        { 1,0,0,0,0,0,0,0,0,0,0,1 },
        { 1,0,0,0,0,0,0,0,0,0,0,1 },
        { 1,0,0,0,0,0,0,0,0,0,0,1 },
        { 1,0,0,0,0,0,0,0,0,0,0,1 },
        { 1,0,0,0,0,0,0,0,0,0,0,1 },
        { 1,0,0,0,0,0,0,0,0,0,0,1 },
        { 1,0,0,0,0,0,0,0,0,0,0,1 },
        { 1,0,0,0,0,0,0,0,0,0,0,1 },
        { 1,0,0,0,0,0,0,0,0,0,0,1 },
        { 1,0,0,0,0,0,0,0,0,0,0,1 },
        { 1,0,0,0,0,0,0,0,0,0,0,1 },
        { 1,0,0,0,0,0,0,0,0,0,0,1 },
        { 1,0,0,0,0,0,0,0,0,0,0,1 },
        { 1,0,0,0,0,0,0,0,0,0,0,1 },
        { 1,0,0,0,0,0,0,0,0,0,0,1 },
        { 1,0,0,0,0,0,0,0,0,0,0,1 },
        { 1,0,0,0,0,0,0,0,0,0,0,1 },
        { 1,0,0,0,0,0,0,0,0,0,0,1 },
        { 1,0,0,0,0,0,0,0,0,0,0,1 },
        { 1,1,1,1,1,1,1,1,1,1,1,1 }
    };
    [SerializeField, Multiline(23)]
    string debugFiledData = "";


    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private Transform spawnPoint;

    [Space(10)]

    [SerializeField]
    private GameObject startStage;
    [SerializeField]
    private GameObject inGameStage;

    private void Awake()
    {
        Current = this;
    }

    private IEnumerator Start()
    {
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

        startStage.SetActive(false);

        while (true)
        {
            var t = Instantiate(prefab, spawnPoint).GetComponent<Tetorimino>();
            updateDebugFieldData();



            yield return new WaitUntil(() => !t.IsDown);

            Debug.Log("aaa");
        }
    }

    private void updateDebugFieldData()
    {
        string mes = "";
        for (int i = 0; i < FieldData.GetLength(0); i++)
        {

            for (int j = 0; j < FieldData.GetLength(1); j++)
            {
                var blockIcon = (FieldData[i, j] == 0 ? " " : "¡");
                mes += $"{blockIcon} ";
            }

            if (i < FieldData.GetLength(0) - 1)
            {
                mes += "\n";
            }
        }

        debugFiledData = mes;
    }
}
