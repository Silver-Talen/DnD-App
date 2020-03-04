using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SimpleJSON;
using System;
using Random = UnityEngine.Random;

public class UI : MonoBehaviour
{
    public GameObject Content;
    public TextMeshProUGUI DisplayText;
    public GameObject DisplayButton;


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

    public void DisplayRandomData()
    {
        Instance.StartCoroutine("DelayedDisplayRandomData");
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
            GameObject ButtonObject;
            ButtonObject = Instantiate(DisplayButton);
            Button ButtonToAdd = ButtonObject.GetComponentInChildren<Button>();
            TextMeshProUGUI TextToDisplay = ButtonToAdd.GetComponentInChildren<TextMeshProUGUI>();
            TextToDisplay.text = data.Name;
            ButtonObject.transform.SetParent(Content.transform);

        }
    }

    IEnumerator DelayedDisplayRandomData()
    {
        yield return new WaitForSeconds(0.7f);

        foreach (Transform child in Content.transform)
        {
            Destroy(child.gameObject);
        }
        int rand = Random.Range(0, DatabaseData.Count);
        string url = DatabaseData[rand].Url.Replace("\"", "");
        APICaller.Instance.ApiCall = url;

        APICaller.Instance.StartCoroutine("GetDetails", "Monster");

        GameObject ButtonObject;
        ButtonObject = Instantiate(DisplayButton);
        Button ButtonToAdd = ButtonObject.GetComponentInChildren<Button>();
        TextMeshProUGUI TextToDisplay = ButtonToAdd.GetComponentInChildren<TextMeshProUGUI>();
        TextToDisplay.text = DatabaseData[rand].Name;
        ButtonObject.transform.SetParent(Content.transform);
    }

}
