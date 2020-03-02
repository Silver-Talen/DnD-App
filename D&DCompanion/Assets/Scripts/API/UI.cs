using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SimpleJSON;
using System;

public class UI : MonoBehaviour
{
    public GameObject Content;
    public TextMeshProUGUI DisplayText = new TextMeshProUGUI();


    public static UI Instance;
    public List<Data> ParsedData;
    public List<Data> DatabaseData;

    void Awake()
    {
        //Set the instance to this script
        Instance = this;
    }

    public void OutputData(string ApiCall)
    {
        APICaller.Instance.ApiCall = ApiCall.ToLower() + "/";
        DND_Database.Instance.ApiCall = ApiCall;
        APICaller.Instance.StartCoroutine("GetData");
        Instance.StartCoroutine("DelayedOpenDatabase");

        Debug.Log("Past the delay");
        
    }

    public void DisplayData()
    {
        Instance.StartCoroutine("DelayedDisplayData");
    }

    IEnumerator DelayedOpenDatabase()
    {
        yield return new WaitForSeconds(0.5f);
        DND_Database.Instance.OpenDatabase();
    }

    IEnumerator DelayedDisplayData()
    {
        yield return new WaitForSeconds(0.7f);

        foreach (Transform child in Content.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Data data in DatabaseData)
        {
            TextMeshProUGUI TextToAdd = new TextMeshProUGUI();
            TextToAdd = Instantiate(DisplayText);
            TextToAdd.text = data.ToString();
            TextToAdd.transform.parent = Content.transform;
        }
    }

}
