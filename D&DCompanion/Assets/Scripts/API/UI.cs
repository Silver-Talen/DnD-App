using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using SimpleJSON;
using System;
using Random = UnityEngine.Random;

public class UI : MonoBehaviour
{
    public GameObject Content;
    public TextMeshProUGUI DisplayText;
    public GameObject DisplayLabel;


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
            
            TextMeshProUGUI TextToDisplay = Instantiate(DisplayText);
            TextToDisplay.text = data.Name;
            TextToDisplay.transform.SetParent(Content.transform);

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

        GameObject label = Instantiate(DisplayLabel);
        TextMeshProUGUI TextToDisplay = label.GetComponentInChildren<TextMeshProUGUI>();
        TextToDisplay.text = DatabaseData[rand].Name;
        label.transform.SetParent(Content.transform);
        label.transform.localScale = new Vector3(1, 1, 1);


    }

    public void DisplayGottenData(List<Monster> data)
    {
        GameObject label = Instantiate(DisplayLabel);
        TextMeshProUGUI text = label.GetComponentInChildren<TextMeshProUGUI>();
        text.text = "Challenge Rating: " + data[0].ChallengeRating;
        label.transform.SetParent(Content.transform);
        label.transform.localScale = new Vector3(1, 1, 1);
        
        #region Size
        label = Instantiate(DisplayLabel);
        text = label.GetComponentInChildren<TextMeshProUGUI>();
        text.text = "Size: " + data[0].Size;
        label.transform.SetParent(Content.transform);
        label.transform.localScale = new Vector3(1, 1, 1);
        #endregion

        #region Type
        label = Instantiate(DisplayLabel);
        text = label.GetComponentInChildren<TextMeshProUGUI>();
        text.text = "Type: " + data[0].Type;
        label.transform.SetParent(Content.transform);
        label.transform.localScale = new Vector3(1, 1, 1);
        #endregion

        #region Subtype
        label = Instantiate(DisplayLabel);
        text = label.GetComponentInChildren<TextMeshProUGUI>();
        text.text = "Subtype: " + data[0].Subtype;
        label.transform.SetParent(Content.transform);
        label.transform.localScale = new Vector3(1, 1, 1);
        #endregion

        #region Alignment
        label = Instantiate(DisplayLabel);
        text = label.GetComponentInChildren<TextMeshProUGUI>();
        text.text = "Alignment: " + data[0].Alignment;
        label.transform.SetParent(Content.transform);
        label.transform.localScale = new Vector3(1, 1, 1);
        #endregion
        
        #region Hit Points
        label = Instantiate(DisplayLabel);
        text = label.GetComponentInChildren<TextMeshProUGUI>();
        text.text = "Hit Points: " + data[0].HitPoints;
        label.transform.SetParent(Content.transform);
        label.transform.localScale = new Vector3(1, 1, 1);
        #endregion
        
        #region Hit Dice
        label = Instantiate(DisplayLabel);
        text = label.GetComponentInChildren<TextMeshProUGUI>();
        text.text = "Hit Dice: " + data[0].HitDice;
        label.transform.SetParent(Content.transform);
        label.transform.localScale = new Vector3(1, 1, 1);
        #endregion

        #region Speed
        label = Instantiate(DisplayLabel);
        text = label.GetComponentInChildren<TextMeshProUGUI>();
        string speed = "\n";
        foreach (var item in data[0].Speed)
        {
            speed += "\t" + item.Key.Replace("\"", string.Empty) + " ";
            speed += item.Value.Replace("\"", string.Empty) + " \n";
        }
        text.text = "Speed: " + speed;
        label.transform.SetParent(Content.transform);
        label.transform.localScale = new Vector3(1, 1, 1);
        #endregion

        #region STR
        label = Instantiate(DisplayLabel);
        text = label.GetComponentInChildren<TextMeshProUGUI>();
        text.text = "STR: " + data[0].Strength;
        label.transform.SetParent(Content.transform);
        label.transform.localScale = new Vector3(1, 1, 1);
        #endregion

        #region DEX
        label = Instantiate(DisplayLabel);
        text = label.GetComponentInChildren<TextMeshProUGUI>();
        text.text = "DEX: " + data[0].Dexterity;
        label.transform.SetParent(Content.transform);
        label.transform.localScale = new Vector3(1, 1, 1);
        #endregion

        #region CON
        label = Instantiate(DisplayLabel);
        text = label.GetComponentInChildren<TextMeshProUGUI>();
        text.text = "CON: " + data[0].Constitution;
        label.transform.SetParent(Content.transform);
        label.transform.localScale = new Vector3(1, 1, 1);
        #endregion

        #region INT
        label = Instantiate(DisplayLabel);
        text = label.GetComponentInChildren<TextMeshProUGUI>();
        text.text = "INT: " + data[0].Intelligence;
        label.transform.SetParent(Content.transform);
        label.transform.localScale = new Vector3(1, 1, 1);
        #endregion

        #region WIS
        label = Instantiate(DisplayLabel);
        text = label.GetComponentInChildren<TextMeshProUGUI>();
        text.text = "WIS: " + data[0].Wisdom;
        label.transform.SetParent(Content.transform);
        label.transform.localScale = new Vector3(1, 1, 1);
        #endregion

        #region CHA
        label = Instantiate(DisplayLabel);
        text = label.GetComponentInChildren<TextMeshProUGUI>();
        text.text = "CHA: " + data[0].Charisma;
        label.transform.SetParent(Content.transform);
        label.transform.localScale = new Vector3(1, 1, 1);
        #endregion

        #region Proficiencies
        label = Instantiate(DisplayLabel);
        text = label.GetComponentInChildren<TextMeshProUGUI>();
        string proficiencies = "\n";
        foreach (var item in data[0].Proficiencies)
        {
            foreach (var prof in item)
            {
                if(prof.Key != "\"url\"")
                {
                    proficiencies += prof.Value.Replace("\"", string.Empty) + " ";
                }
            }
            proficiencies += "\n";
        }
        if(data[0].Proficiencies.Count == 0)
        {
            proficiencies += "None";
        }
        text.text = "Proficiencies: " + proficiencies;
        label.transform.SetParent(Content.transform);
        label.transform.localScale = new Vector3(1, 1, 1);
        #endregion

        #region Damage Vulnerabilities
        label = Instantiate(DisplayLabel);
        text = label.GetComponentInChildren<TextMeshProUGUI>();
        string dmgVuln = "\n";
        foreach (var item in data[0].DamageVulnerabilities)
        {
            dmgVuln += "\t" + item.Replace("\"", string.Empty) + " ";
        }
        if(data[0].DamageVulnerabilities.Count == 0)
        {
            dmgVuln += "None";
        }
        text.text = "Damage Vulnerabilities: " + dmgVuln;
        label.transform.SetParent(Content.transform);
        label.transform.localScale = new Vector3(1, 1, 1);
        #endregion

        #region Damage Resistances
        label = Instantiate(DisplayLabel);
        text = label.GetComponentInChildren<TextMeshProUGUI>();
        string dmgResi = "\n";
        foreach (var item in data[0].DamageResistances)
        {
            dmgResi += "\t" + item.Replace("\"", string.Empty) + " ";
        }
        if (data[0].DamageResistances.Count == 0)
        {
            dmgResi += "None";
        }
        text.text = "Damage Resistances: " + dmgResi;
        label.transform.SetParent(Content.transform);
        label.transform.localScale = new Vector3(1, 1, 1);
        #endregion

        #region Damage Immunities
        label = Instantiate(DisplayLabel);
        text = label.GetComponentInChildren<TextMeshProUGUI>();
        string dmgImmu = "\n";
        foreach (var item in data[0].DamageImmunities)
        {
            dmgImmu += "\t" + item.Replace("\"", string.Empty) + " ";
        }
        if (data[0].DamageImmunities.Count == 0)
        {
            dmgImmu += "None";
        }
        text.text = "Damage Immunities: " + dmgImmu;
        label.transform.SetParent(Content.transform);
        label.transform.localScale = new Vector3(1, 1, 1);
        #endregion

        #region Condition Immunities
        label = Instantiate(DisplayLabel);
        text = label.GetComponentInChildren<TextMeshProUGUI>();
        string condImmu = "\n";
        foreach (var item in data[0].ConditionImmunities)
        {
            foreach (var prof in item)
            {
                if (prof.Key != "\"url\"")
                {
                    condImmu += prof.Value.Replace("\"", string.Empty) + " ";
                }
            }
            condImmu += "\n";
        }
        if (data[0].Proficiencies.Count == 0)
        {
            condImmu += "None";
        }
        text.text = "Condition Immunities: " + condImmu;
        label.transform.SetParent(Content.transform);
        label.transform.localScale = new Vector3(1, 1, 1);
        #endregion

        #region Senses
        label = Instantiate(DisplayLabel);
        text = label.GetComponentInChildren<TextMeshProUGUI>();
        string senses = "\n";
        foreach (var item in data[0].Senses)
        {
            senses += "\t" + item.Key.Replace("\"", string.Empty) + " ";
            senses += item.Value.Replace("\"", string.Empty) + " \n";
        }
        text.text = "Senses: " + senses;
        label.transform.SetParent(Content.transform);
        label.transform.localScale = new Vector3(1, 1, 1);
        #endregion

        #region Languages
        label = Instantiate(DisplayLabel);
        text = label.GetComponentInChildren<TextMeshProUGUI>();
        text.text = "Languages: " + data[0].Languages;
        label.transform.SetParent(Content.transform);
        label.transform.localScale = new Vector3(1, 1, 1);
        #endregion

        #region Special Abilities
        label = Instantiate(DisplayLabel);
        text = label.GetComponentInChildren<TextMeshProUGUI>();
        string specAbil = "\n";
        foreach (var item in data[0].SpecialAbilities)
        {
            foreach (var prof in item)
            {
                if (prof.Key != "\"url\"")
                {
                    specAbil += prof.Value.Replace("\"", string.Empty) + " ";
                }
            }
            specAbil += "\n";
        }
        if (data[0].SpecialAbilities.Count == 0)
        {
            specAbil += "None";
        }
        text.text = "Special Abilities: " + specAbil;
        label.transform.SetParent(Content.transform);
        label.transform.localScale = new Vector3(1, 1, 1);
        #endregion

        #region Actions
        label = Instantiate(DisplayLabel);
        text = label.GetComponentInChildren<TextMeshProUGUI>();
        string actions = "\n";
        foreach (var item in data[0].Actions)
        {
            foreach (var prof in item)
            {
                if (prof.Key != "\"url\"")
                {
                    actions += prof.Value.Replace("\"", string.Empty) + " ";
                }
            }
            actions += "\n";
        }
        if (data[0].Actions.Count == 0)
        {
            actions += "None";
        }
        text.text = "Actions: " + actions;
        label.transform.SetParent(Content.transform);
        label.transform.localScale = new Vector3(1, 1, 1);
        #endregion



        Instance.StartCoroutine("RefreshContent");
    }

    IEnumerator RefreshContent()
    {
        yield return new WaitForSeconds(0.01f);
        Content.GetComponent<ContentSizeFitter>().enabled = false;
        Content.GetComponent<ContentSizeFitter>().enabled = true;
    }
}
