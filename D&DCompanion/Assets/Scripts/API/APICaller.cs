using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;
using System;
using System.Linq;
using SimpleJSON;

//THIS CLASS WAS CREATED USING A TUTORIAL FOUND AT THE URL BELOW
//https://gamedevacademy.org/how-to-connect-to-an-api-with-unity/

public class APICaller : MonoBehaviour
{
    //API URL
    public string Url;

    //Resulting JSON from an API request
    public JSONNode JsonResult;

    //Instance of APICaller
    public static APICaller Instance;

    void Awake()
    {
        //Set the instance to be this script
        Instance = this;
    }

    //Sends an API request - Returns a JSON file
    IEnumerator GetData(string Location)
    {
        //Create the web request and download handler
        UnityWebRequest WebReq = new UnityWebRequest();
        WebReq.downloadHandler = new DownloadHandlerBuffer();

        //Build the url and query
        WebReq.url = string.Format("{0}&q={1}", Url, Location);

        //Send the web request and wait for a returning result
        yield return WebReq.SendWebRequest();

        //Convert the byte array and wait for a returning result
        string RawJson = Encoding.Default.GetString(WebReq.downloadHandler.data);

        //Parse the raw string into a json result we can easily read
        JsonResult = JSON.Parse(RawJson);

        UI.instance.SetSegments(JsonResult["result"]);
    }
    
    public void FilterData()
    {

    }
}
