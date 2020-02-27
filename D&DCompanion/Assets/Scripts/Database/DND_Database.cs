using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;
using SimpleJSON;

//THIS CLASS WAS CREATED USING A TUTORIAL FOUND AT THE URL BELOW
//https://answers.unity.com/questions/743400/database-sqlite-setup-for-unity.html

public class DND_Database : MonoBehaviour
{
    public static DND_Database Instance;
    public List<Data> ParsedData;

    bool isDatabaseEmpty = true;

    void Awake()
    {
        //Set the instance to this script
        Instance = this;
    }

    // Start is called before the first frame update
    public void OpenDatabase()
    {
        //Path to database
        string Connection = "URI=file:" + Application.dataPath + "/Databases/DND_Data.db";
        
        IDbConnection DBConnection;
        //Gets the Database using the connection
        DBConnection = new SqliteConnection(Connection);
        //Opens the connection to the database
        DBConnection.Open();
        IDbCommand DBCommand = DBConnection.CreateCommand();

        if(isDatabaseEmpty)
        {
            string sqlQuery = "INSERT INTO Equipment(" + '"' + "Index" + '"' + ", " + '"' + "Name" + '"' + ", " + '"' + "Url" + '"' + ") VALUES";
            foreach (Data data in ParsedData)
            {
                sqlQuery += "(" + $"{data.Index}" + ", " + $"{data.Name}" + ", " + $"{data.Url}" + "),";
            }
            sqlQuery = sqlQuery.Remove(sqlQuery.Length - 1, 1);
            sqlQuery += ";";
            DBCommand.CommandText = sqlQuery;
            IDataReader reader = DBCommand.ExecuteReader();
            
            isDatabaseEmpty = false;

            reader.Close();
            reader = null;
            DBCommand.Dispose();
            DBCommand = null;
            DBConnection.Close();
            DBConnection = null;
        }
        else
        {
            string sqlQuery = "SELECT * FROM Equipment";
            DBCommand.CommandText = sqlQuery;
            IDataReader reader = DBCommand.ExecuteReader();

            while (reader.Read())
            {
                Debug.Log("This ain't it chief");

            }

            reader.Close();
            reader = null;
            DBCommand.Dispose();
            DBCommand = null;
            DBConnection.Close();
            DBConnection = null;
        }
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
}
