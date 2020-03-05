using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;
using SimpleJSON;
using System.Linq;
using System.Text.RegularExpressions;

//THIS CLASS WAS CREATED USING A TUTORIAL FOUND AT THE URL BELOW
//https://answers.unity.com/questions/743400/database-sqlite-setup-for-unity.html

public class DND_Database : MonoBehaviour
{
    public static DND_Database Instance;
    public List<Data> ParsedData;
    public string ApiCall;

    #region Database Connections
    
    IDbConnection DBConnection;
    IDbCommand DBCommand;
    IDataReader reader;

    #endregion

    bool isDatabaseEmpty = true;

    void Awake()
    {
        //Set the instance to this script
        Instance = this;
    }

    void CheckIfDatabaseEmpty()
    {
        //Path to database
        string Connection = "URI=file:" + Application.dataPath + "/Databases/DND_Data.db";

        //Gets the Database using the connection
        DBConnection = new SqliteConnection(Connection);
        //Opens the connection to the database
        DBConnection.Open();
        DBCommand = DBConnection.CreateCommand();

        string sqlQuery = "SELECT * FROM " + ApiCall;
        DBCommand.CommandText = sqlQuery;
        reader = DBCommand.ExecuteReader();

        isDatabaseEmpty = !reader.Read();

        reader.Close();
        reader = null;
        DBCommand.Dispose();
        DBCommand = null;
        DBConnection.Close();
        DBConnection = null;
    }

    // Start is called before the first frame update
    public void OpenDatabase()
    {
        CheckIfDatabaseEmpty();

        if(isDatabaseEmpty)
        {
            GenerateDatabase();
            GrabDatabase();
        }
        else
        {
            GrabDatabase();
            Debug.Log(ApiCall);
        }
               
        
    }

    void GenerateDatabase()
    {
        //Path to database
        string Connection = "URI=file:" + Application.dataPath + "/Databases/DND_Data.db";

        //Gets the Database using the connection
        DBConnection = new SqliteConnection(Connection);
        //Opens the connection to the database
        DBConnection.Open();
        DBCommand = DBConnection.CreateCommand();

        if (isDatabaseEmpty)
        {
            string sqlQuery = "INSERT INTO " + ApiCall + "(" + '"' + "Index" + '"' + ", " + '"' + "Name" + '"' + ", " + '"' + "Url" + '"' + ") VALUES";
            foreach (Data data in ParsedData)
            {
                sqlQuery += "(" + $"{data.Index}" + ", " + $"{data.Name}" + ", " + $"{data.Url}" + "),";
            }
            sqlQuery = sqlQuery.Remove(sqlQuery.Length - 1, 1);
            sqlQuery += ";";
            DBCommand.CommandText = sqlQuery;
            reader = DBCommand.ExecuteReader();

            isDatabaseEmpty = false;

        }
        reader.Close();
        reader = null;
        DBCommand.Dispose();
        DBCommand = null;
        DBConnection.Close();
        DBConnection = null;
    }

    void GrabDatabase()
    {
        //Path to database
        string Connection = "URI=file:" + Application.dataPath + "/Databases/DND_Data.db";

        //Gets the Database using the connection
        DBConnection = new SqliteConnection(Connection);
        //Opens the connection to the database
        DBConnection.Open();
        DBCommand = DBConnection.CreateCommand();

        string sqlQuery = "SELECT * FROM " + ApiCall;
        DBCommand.CommandText = sqlQuery;
        reader = DBCommand.ExecuteReader();

        List<Data> DatabaseData = new List<Data>();
        while (reader.Read())
        {
            Data data = new Data(reader.GetString(1), reader.GetString(2), reader.GetString(3));
            string index = reader.GetString(1);
            string name = reader.GetString(2);
            string url = reader.GetString(3);
            DatabaseData.Add(data);

        }
        UI.Instance.DatabaseData = DatabaseData;

        reader.Close();
        reader = null;
        DBCommand.Dispose();
        DBCommand = null;
        DBConnection.Close();
        DBConnection = null;
    }

    public void FetchData(JSONNode records)
    {
        ParsedData = new List<Data>();
        foreach (JSONNode item in records)
        {
            Data data = new Data(item["index"], item["name"], item["url"]);
            ParsedData.Add(data);
        }
    }

    public void FetchData(JSONNode records, string type)
    {
        switch (type)
        {
            case "Equipment":
                break;
            case "Monster":
                ParseMonsterData(records);
                List<Monster> data = ParsedData.Cast<Monster>().ToList();
                UI.Instance.DisplayGottenData(data);
                break;
            case "Weapon":
                break;
            default:
                break;
        }
    }

    void ParseMonsterData(JSONNode records)
    {
        ParsedData = new List<Monster>().Cast<Data>().ToList();

        Monster monster = new Monster(records["index"], records["name"], records["url"]);

        monster.Size = records["size"];
        monster.Type = records["type"];
        monster.Subtype = records["subtype"];
        monster.Alignment = records["alignment"];
        monster.ArmorClass = records["armor_class"];
        monster.HitPoints = records["hit_points"];
        monster.HitDice = records["hit_dice"];

        //This needs to be a list
        monster.Speed = ConvertToDictionary(records, "speed");
        
        
        monster.Strength = records["strength"];
        monster.Dexterity = records["dexterity"];
        monster.Constitution = records["constitution"];
        monster.Intelligence = records["wisdom"];
        monster.Wisdom = records["wisdom"];
        monster.Charisma = records["charisma"];


        //This needs to be a list
        monster.Proficiencies = new List<Dictionary<string, string>>();
        foreach (JSONNode item in records["proficiencies"].AsArray)
        {
            monster.Proficiencies.Add(ConvertToDictionary(item));
        }

        //This needs to be a list
        monster.DamageVulnerabilities = new List<string>();
        foreach (JSONNode item in records["damage_vulnerabilities"].AsArray)
        {
            monster.DamageVulnerabilities.Add(item);
        }

        //This needs to be a list
        monster.DamageResistances = new List<string>();
        foreach (JSONNode item in records["damage_resistances"].AsArray)
        {
            monster.DamageResistances.Add(item);
        }

        //This needs to be a list
        monster.DamageImmunities = new List<string>();
        foreach (JSONNode item in records["damage_immunities"].AsArray)
        {
            monster.DamageImmunities.Add(item);
        }

        //This needs to be a list
        monster.ConditionImmunities = new List<Dictionary<string, string>>();
        foreach (JSONNode item in records["condition_immunities"].AsArray)
        {
            monster.ConditionImmunities.Add(ConvertToDictionary(item));
        }

        //This needs to be a list
        monster.Senses = ConvertToDictionary(records, "senses");

        monster.Languages = records["languages"];
        monster.ChallengeRating = records["challenge_rating"];

        //This needs to be a list
        monster.SpecialAbilities = new List<Dictionary<string, string>>();
        foreach (JSONNode item in records["special_abilities"].AsArray)
        {
            monster.SpecialAbilities.Add(ConvertToDictionarySimple(item));
        }

        //This needs to be a list
        monster.Actions = new List<Dictionary<string, string>>();
        foreach (JSONNode item in records["special_abilities"].AsArray)
        {
            monster.Actions.Add(ConvertToDictionarySimple(item));
        }

        ParsedData.Add(monster);
    }

    Dictionary<string, string> ConvertToDictionary(JSONNode records, string record)
    {
        Dictionary<string, string> dictionary = new Dictionary<string, string>();

        string recordsStr = records[record].AsObject.ToString();
        recordsStr = recordsStr.Replace("{", string.Empty);
        recordsStr = recordsStr.Replace("}", string.Empty);
        string[] recordsList = Regex.Split(recordsStr, @"(?:[^""]*\B[,])");
            //recordsStr.Split(',').ToList();
        foreach (string item in recordsList)
        {
            string[] recordArr = Regex.Split(item, @"(?:[^""]*\B[:])");
            dictionary.Add(recordArr[0], recordArr[1].ToString());
        }

        return dictionary;
    }

    Dictionary<string, string> ConvertToDictionary(JSONNode records)
    {
        Dictionary<string, string> dictionary = new Dictionary<string, string>();

        string recordsStr = records.AsObject.ToString();
        recordsStr = recordsStr.Replace("{", string.Empty);
        recordsStr = recordsStr.Replace("}", string.Empty);
        string[] recordsList = Regex.Split(recordsStr, @"(?:[^""]*\B[,])");
        foreach (string item in recordsList)
        {
            string[] recordArr = Regex.Split(item, @"(?:[^""]*\B[:])");
            dictionary.Add(recordArr[0], recordArr[1].ToString());
        }

        return dictionary;
    }

    Dictionary<string, string> ConvertToDictionarySimple(JSONNode records)
    {
        Dictionary<string, string> dictionary = new Dictionary<string, string>();
        dictionary.Add("name", records["name"]);
        dictionary.Add("desc", records["desc"]);
        
        return dictionary;
    }
}
