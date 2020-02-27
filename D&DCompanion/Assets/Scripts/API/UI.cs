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

    void Start()
    {
        APICaller.Instance.StartCoroutine("GetData");
    }

    public void OutputData()
    {
        DND_Database.Instance.OpenDatabase();

        //foreach (Data data in ParsedData)
        //{
        //    TextMeshProUGUI TextToAdd = new TextMeshProUGUI();
        //    TextToAdd = Instantiate(DisplayText);
        //    TextToAdd.text = data.ToString();
        //    TextToAdd.transform.parent = Content.transform;
        //}
    }

}
