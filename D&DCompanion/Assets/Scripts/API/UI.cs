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
        //foreach (Data data in ParsedData)
        //{
        //    TextMeshProUGUI TextToAdd = new TextMeshProUGUI();
        //    TextToAdd = Instantiate(DisplayText);
        //    TextToAdd.text = data.ToString();
        //    TextToAdd.transform.parent = Content.transform;
        //}
    }

    IEnumerator DelayedOpenDatabase()
    {
        yield return new WaitForSeconds(0.5f);
        DND_Database.Instance.OpenDatabase();
    }

}
