using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadHandler : MonoBehaviour
{
    #region Variables
    public GameObject bobPrefab;
    public static string loadPath;
    #endregion

    private void Awake()
    {
        if (loadPath != null)
        {
            GameObject clone = Instantiate(bobPrefab);

            Transform cloneTrans = clone.transform;
            SavePlayerData.ReadSaveFile(loadPath, ref cloneTrans);
        }
    }


    public void SaveGame()
    {
        Transform player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        SavePlayerData.WriteSaveFile(SaveLoadHandler.loadPath, player);
    }

    public void LoadGame()
    {
        Transform player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        SavePlayerData.ReadSaveFile(SaveLoadHandler.loadPath, ref player);
    }
}
