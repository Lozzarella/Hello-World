using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SaveTest : MonoBehaviour
{
    public Transform player;
    //public PlayerData playerData;

    private void Start()
    {
        
            
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SaveGame()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        SaveData.WriteSaveFile(StartBobsWorld.loadPath, player);
    }

    public void LoadGame()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        SaveData.ReadSaveFile(StartBobsWorld.loadPath, ref player);
    }

    public void LoadButton()
    {
        
        SceneManager.LoadScene(1);
    }
}
