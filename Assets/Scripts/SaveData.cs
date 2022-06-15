using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor; //to make our own tool && update our editor
using System; //convert a string to an enum
using System.IO; //access to characters from a byte streamSystem.DateTime.Now


[System.Serializable]

public class SaveData : MonoBehaviour
{
    #region Variables

    public static string path1 = "Assets/StreamingAssets/Save/Slot1.txt";//This is the file path for save slot 1
    public static string path2 = "Assets/StreamingAssets/Save/Slot2.txt";//This is the file path for save slot 2
    public static string path3 = "Assets/StreamingAssets/Save/Slot3.txt";//This is the file path for save slot 3
    #endregion

    public static void WriteSaveFile(string path, Transform player)
    {
        //true means you can add to the file
        //false means you override what was in the file
        StreamWriter writer = new StreamWriter(path, false);

        //Each Key name and Key Value will be written in with a : to seperate them
        writer.WriteLine("Save Time|" + DateTime.Now.ToString());
        writer.WriteLine("Player Name|" + player.name);
//health
        writer.WriteLine("Player Position|" + player.position.ToString());
        writer.WriteLine("Player Rotation|" + player.rotation.ToString());
        Debug.Log(player.position.ToString());

        //writng is done
        writer.Close();//closes the current Streamwriter object and the underlying stream

        //Re-import the file to update the reference in the editor
        AssetDatabase.ImportAsset(path);
        //TextAsset asset = Resources.Load("Save/Keybinds.txt") as TextAsset;
    }

    public static void ReadSaveFile(string path, ref Transform playerTrans)
    {
        //Read text from file
        StreamReader reader = new StreamReader(path);
        //ref to the line we are reading
        string line;
        //using lists to add 
        List<string> saveInfo = new List<string>();
        List<float> data = new List<float>();

        PlayerData player = new PlayerData();

        while ((line = reader.ReadLine()) != null)
        {
            //creates an array of strings by splitting the line where the character | is 
            string[] lines = line.Split('|');
            //if our save data side contains a (
            if (lines[1].Contains("("))
            {
                //we need to remove ( and )
                lines[1] = lines[1].Replace("(", "");
                lines[1] = lines[1].Replace(")", "");
            }          
            //now all edits are done add our line of data to the list of save data
            saveInfo.Add(lines[1]);
        }

        //load player name straight from our string list
        player.name = saveInfo[1];
        #region Splitting and Loading position vector3
        string[] storeData = saveInfo[2].Split(',');
        for (int i = 0; i < storeData.Length; i++)
        {
            data.Add(float.Parse(storeData[i]));
        }        
        player.playerData.position = new Vector3(data[0], data[1], data[2]);
        Debug.Log(player.playerData.position.ToString());
        Debug.Log(new Vector3(data[0], data[1], data[2]).ToString());
        #endregion
        #region Splitting and l=Loading rotation quaternion 
        data.Clear();
        storeData = saveInfo[3].Split(',');
        for (int i = 0; i < storeData.Length; i++)
        {
            data.Add(float.Parse(storeData[i]));
        }
        player.playerData.rotation = new Quaternion(data[0],data[1], data[2],data[3]);
        #endregion
        reader.Close();

        player.LoadToTransform(ref playerTrans);
    }
}
