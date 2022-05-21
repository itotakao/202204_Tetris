using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class GameLauncuer : MonoBehaviour
{
    [SerializeField]
    int[,] fieldData = new int[,] {
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

    private IEnumerator Start()
    {
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

        startStage.SetActive(false);
        Instantiate(prefab, spawnPoint);
        updateDebugFieldData();
        while (true)
        {
            yield return null;
        }
    }

    private void updateDebugFieldData()
    {
        string mes = "";
        for (int i = 0; i < fieldData.GetLength(0); i++)
        {

            for (int j = 0; j < fieldData.GetLength(1); j++)
            {
                var blockIcon = (fieldData[i, j] == 0 ? " " : "¡");
                mes += $"{blockIcon} ";
            }

            if (i < fieldData.GetLength(0) - 1)
            {
                mes += "\n";
            }
        }

        debugFiledData = mes;
    }
}
