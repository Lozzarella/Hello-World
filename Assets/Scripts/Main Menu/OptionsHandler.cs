using UnityEngine; //Resources.Load
using UnityEditor; //to make our own tool && update our editor
using System; //convert a string to an enum
using System.IO; //access to characters from a byte stream
public class OptionsHandler
{
    //path
    static string path = "Assets/StreamingAssets/Save/Options.txt";

    public static void WriteOptionSaveData()
    {
        //writer
        StreamWriter writer = new StreamWriter(path, false);

        //save info
        //Quality save an int

        writer.WriteLine(MenuHandler.tempQuality);
        //Fullscreen bool
        writer.WriteLine(MenuHandler.tempFullscreen);

        //Resolution int
        writer.WriteLine(MenuHandler.tempResolution);

        //close writer
        writer.Close();//closes the current Streamwriter object and the underlying stream

    }
    public static void ReadOptionSaveData()
    {
        //reader
        StreamReader reader = new StreamReader(path);
        MenuHandler.tempQuality = Int32.Parse(reader.ReadLine());
        MenuHandler.tempFullscreen = bool.Parse(reader.ReadLine());
        MenuHandler.tempResolution = Int32.Parse(reader.ReadLine());

        //close reader
        reader.Close();
    }
}
