using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SymptomsControler : MonoBehaviour
{
    public GameObject detailWindow;
    public GameObject inputField;
    public Dropdown dropDown;

    public GameObject Content;
    public GameObject Pref;
    void Start()
    {
        Symptoms.LoadFromFile();
    }

    public void OutputSymptom(string nazv)
    {
        detailWindow.SetActive(true);

        if (Symptoms.GetBoolDropDown(nazv) != null)
        {
            if (dropDown.options.Count == 0)
                dropDown.AddOptions(Symptoms.GetBoolDropDown(nazv));
            else {
                dropDown.ClearOptions(); 
                dropDown.AddOptions(Symptoms.GetBoolDropDown(nazv));
            }
            dropDown.gameObject.SetActive(true);
        }
    }

    public void WriteFile(Text Symptom)
    {
        Symptoms.Write(Symptom.text);
    }

    public void ClearWriteFile()
    {
        Symptoms.DeleteWriteFile();
    }

    public void Fill()
    {
        for (int i = 0; i < Symptoms.CurrentSymptoms.Count; i++)
        {
            GameObject temp= Instantiate(Pref);
            temp.GetComponentInChildren<Text>().text = Symptoms.CurrentSymptoms[i];
            temp.transform.SetParent(Content.transform);
            temp.GetComponent<RectTransform>().localPosition = new Vector3(temp.GetComponent<RectTransform>().localPosition.x,
                temp.GetComponent<RectTransform>().localPosition.y, 0);
            temp.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        }
    }
}
