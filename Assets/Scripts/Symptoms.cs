using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public static class Symptoms
{
    private static string Path = Application.dataPath + "/StreamingAssets/Symptoms.txt";
    //private static string WriteFile = Application.dataPath + "/StreamingAssets/CurrentSymptoms.txt";
    public static List<string> CurrentSymptoms = new List<string>();


    public struct Symptom
    {
        public char sign;
        public string tagSymptom;
        public int countVar;
        public List<string> detailsSymptom;

        public Symptom(char ch, string tag, string stroka)
        {
            sign = ch;
            tagSymptom = tag;
            string[] variables = stroka.Split(';');
            detailsSymptom = new List<string>();
            countVar = variables.Length;
            for (int i = 0; i < countVar; i++)
            {
                detailsSymptom.Add(variables[i]);
            }
        }
        public List<string> GetDetails()
        {
            return detailsSymptom;

        }
    };

    public struct AdditionalSymptom
    {
        public char sign;
        public string nameSymptom;
        public bool isInputField;

        public AdditionalSymptom(char ch, string name, bool b)
        {
            sign = ch;
            nameSymptom = name;
            isInputField = b;
        }

    };

    static List<Symptom> symptomsList = new List<Symptom>();
    static List<AdditionalSymptom> additionalSymptomsList = new List<AdditionalSymptom>();
    // Загрузка списка рекордов из файла
    public static void LoadFromFile()
    {
        if (File.Exists(Path))
        {
            int k = 0;
            string[] data = new string[3];
            StreamReader streamR = new StreamReader(Path);
            string tempS;

            while ((tempS = streamR.ReadLine()) != null)
            {
                data[k] = tempS;
                if (data[0] == "!")
                {
                    k++;
                    if (k == 3)
                    {
                        symptomsList.Add(new Symptom(Convert.ToChar(data[0]), data[1], data[2]));
                        k = 0;
                    }
                }
                else if (data[k] == "#")
                {
                    k++;
                    if (k == 3)
                    {
                        additionalSymptomsList.Add(new AdditionalSymptom(Convert.ToChar(data[0]), data[1], Boolean.TryParse(data[2], out bool b)));
                        k = 0;
                    }
                }
            }

        }
    }

    public static List<string> GetBoolDropDown(string nazv)
    {
        for (int i = 0; i < symptomsList.Count; i++)
        {
            if (symptomsList[i].tagSymptom == nazv)
            {
                if (symptomsList[i].countVar != 0) return symptomsList[i].GetDetails();
            }

        }
        return null;
    }

    public static void Write(string Symptom)
    {
        Debug.Log(Symptom);
        // StreamWriter streamW = new StreamWriter(WriteFile, true);
        // streamW.WriteLine(Symptom);
        // DeleteWriteFile();
        // streamW.Close();
        CurrentSymptoms.Add(Symptom);
    }

    public static void DeleteWriteFile()
    {
        //StreamWriter streamW = new StreamWriter(WriteFile);
        // File.Delete(WriteFile);
        CurrentSymptoms.Clear();
    }


}
