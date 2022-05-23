using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class Deserializer : MonoBehaviour
{
    private SomeData[] data;
    private const string PATH = @"Assets\1\Resources\DataBase_ParsedToJson.txt";

    private SomeData[] DeserializedBD()
    {
        using (StreamReader file = File.OpenText(PATH))
        {
            JsonSerializer serializer = new JsonSerializer();
            SomeDataBase db = (SomeDataBase)serializer.Deserialize(file, typeof(SomeDataBase));
            data = db.SomeDB; 
        }

        return data;
    }
    void Start()
    {
        SomeData[] db = DeserializedBD();
        foreach (SomeData data in db)
        {
            Debug.Log($"{data.Name} {data.Description}");
        }
    }
}
