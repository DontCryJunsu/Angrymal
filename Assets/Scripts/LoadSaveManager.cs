using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Mono.Data.SqliteClient;
using System.IO;
using System.Data;

public class Item
{
    public int ID;
    public string Name;
    public string Des;

    public Item(int id, string name, string des)
    {
        ID = id;
        Name = name;
        Des = des;
    }
}

public class LoadSaveManager : MonoBehaviour {

    void Start()
    {
        StartCoroutine(Main());
    }

    IEnumerator Main()
    {
        yield return StartCoroutine(ItemDbParsing("ItemDb.sqlite"));
    }

    IEnumerator ItemDbParsing(string p)
    {


        yield return null;
    }


}
