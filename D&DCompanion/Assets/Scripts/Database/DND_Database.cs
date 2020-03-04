using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;
using SimpleJSON;
using System.Linq;

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

            Debug.Log("INDEX: " + index + " NAME: " + name + " URL: " + url);

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
        
            Monster monster = new Monster(records["index"], records["name"], records["url"],
                records["size"], records["type"], records["subtype"], records["alignment"],
                records["armor_class"], records["hit_points"], records["hit_dice"], records["speed"].Value,
                records["strength"], records["dexterity"], records["constitution"], records["intelligence"],
                records["wisdom"], records["charisma"], records["proficiencies"], records["damage_vulnerabilities"],
                records["damage)resistances"], records["damage_immunities"], records["condition_immunities"],
                records["senses"], records["languages"], records["challenge_rating"], records["special_abilities"],
                records["actions"]);
            ParsedData.Add(monster);
        
    }
}
