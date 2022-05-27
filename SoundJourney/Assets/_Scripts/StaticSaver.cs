using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using UnityEngine;

public class StaticSaver : MonoBehaviour
{
    public static void SaveStuff(List<saveInfo> Signals, string saveName)
    {
        String path = Application.persistentDataPath
                         + @"/MySaveData_" + saveName + ".csv";
        try
        {
            //BinaryFormatter bf = new BinaryFormatter();
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            //Create the file.
            using (FileStream fs = File.Create(path))
            {

                AddText(fs, "Time");
                AddText(fs, ";");
                AddText(fs, "Signal");
                AddText(fs, "\n");

                foreach (saveInfo v in Signals)
                {
                    AddText(fs, v.Time.ToString("G", CultureInfo.CreateSpecificCulture("en-US")));
                    AddText(fs, ";");
                    AddText(fs, v.SignalVal.ToString("G", CultureInfo.CreateSpecificCulture("en-US")));
                    AddText(fs, "\n");
                }

            }

            Debug.Log("Game data saved!");
        }
        catch (Exception e)
        {
            Debug.Log("hmm");
            Debug.Log(e.Message);
        }
    }
    private static void AddText(FileStream fs, string value)
    {
        byte[] info = new UTF8Encoding(true).GetBytes(value);
        fs.Write(info, 0, info.Length);
    }
}
public class saveInfo
{
    public float Time { get; set; }
    public float SignalVal { get; set; }

}
