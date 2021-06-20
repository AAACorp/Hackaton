using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Record : MonoBehaviour
{
    private static string Path = Application.dataPath + "/StreamingAssets/CurrentSymptoms.txt";

    public void WriteLine(Text Symptom)
    { 
        StreamWriter streamW = new StreamWriter(Path);
        streamW.WriteLine(Symptom.text);
    }
}
