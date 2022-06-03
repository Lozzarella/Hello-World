using UnityEngine; //Resources.Load
using UnityEditor; //to make our own tool && update our editor
using System; //convert a string to an enum
using System.IO; //access to characters from a byte stream

// byte == 8 bits /group of bits
// A bit (short for binary digit) is the smallest unit of data in a computer. A bit has a single binary value, either 0 or 1.
//stream is a sequence/ a sequence is a succession
// byte stream == succession of a group of bits

public class HandleTextFile
{
    //at this file location
    static string path2 = "Assets/StreamingAssets/Save/Keybinds.txt";
    // static string path = Path.Combine(Application.streamingAssetsPath + "Save/Keybinds.txt");
    //Unity Editor allows me to create a tool in my Menus
    [MenuItem("Tool/Save/Write File/Keybinds")]//we can attach to unity toolbar
    //This is public static behaviour that we can call in our scripts
    public static void WriteSaveFile()
    {
        //true means you can add to the file
        //false means you override what was in the file
        StreamWriter writer = new StreamWriter(path2, true);

        //write each of our keys in the file
        foreach (var key in KeyBinds.keys)//for each value/string/entry in our dictionary
        {
            //Each Key name and Key Value will be written in with a : to seperate them
            writer.WriteLine(key.Key + ":" + key.Value.ToString());
        }

        //writng is done
        writer.Close();//closes the current Streamwriter object and the underlying stream

        //Re-import the file to update the reference in the editor
        AssetDatabase.ImportAsset(path2);
        //TextAsset asset = Resources.Load("Save/Keybinds.txt") as TextAsset;
    }

    [MenuItem("Tool/Save/Read File/Keybinds")]
    public static void ReadSaveFile()
    {
        //Read text from fike
        StreamReader reader = new StreamReader(path2);
        //ref to the line we are reading
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            string[] parts = line.Split(':');
            //if we have keys and are just updating
            if (KeyBinds.keys.Count > 0)//update key
            {
                KeyBinds.keys[parts[0]] = (KeyCode)System.Enum.Parse(typeof(KeyCode), parts[1]);
            }
            //else we need to also make the keys when we load
            else//add key
            {
                KeyBinds.keys.Add(parts[0], (KeyCode)System.Enum.Parse(typeof(KeyCode), parts[1]));
            }
        }
        reader.Close();


    }
}
