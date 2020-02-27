using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data
{
    public string Index;
    public string Name;
    public string Url;

    public Data(string index, string name, string url)
    {
        Index = '"' + index + '"';
        Name = '"' + name + '"';
        Url = '"' + url + '"';
    }

    public override string ToString()
    {
        return "Index: " + Index + "\nName: " + Name + "\nUrl: " + Url;
    }
}
