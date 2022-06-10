using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTest : MonoBehaviour
{
    public Transform player;
    public PlayerData playerData;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            SaveData.WriteSaveFile(SaveData.path1, player);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            SaveData.ReadSaveFile(SaveData.path1, playerData);
        }
    }
}
