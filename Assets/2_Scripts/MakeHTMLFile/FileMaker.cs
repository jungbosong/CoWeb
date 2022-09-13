using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FileMaker : MonoBehaviour
{       
    public void  MakeFile(string data, string fileName)
    {
        string path = Application.persistentDataPath + fileName + ".htm";
        StreamWriter sw;
        FileStream fs;

        if(!File.Exists(path))
        {
            fs = new FileStream(path, FileMode.Create, FileAccess.Write);
            sw = new StreamWriter(fs);
            sw.WriteLine(data);
            sw.Flush();
            sw.Close();
            fs.Close();

        }
        else if(File.Exists(path))
        {
            File.Delete(path);
            MakeFile(data, fileName);
        }
    }
}
