using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBobsWorld : MonoBehaviour
{
    public GameObject bobPrefab;
    public SaveTest saveTest;
    public static string loadPath;
    private void Awake()
    {
       GameObject clone = Instantiate(bobPrefab);
        saveTest.player = clone.transform;

        Transform cloneTrans = clone.transform;
        SaveData.ReadSaveFile(loadPath, ref cloneTrans);
    }
}
