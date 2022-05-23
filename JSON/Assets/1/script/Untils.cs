using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class Untils : MonoBehaviour
{
    private const string PATH = @"Assets\1\Resources\DataBase_ParsedToJson.txt";
    public static void ParseCSV()
    {
        TextAsset content = Resources.Load<TextAsset>("DataBase");

        string contentString = content.text;
        string[] contentLines = contentString.Split('\n');

        List<SomeData> someDB = new List<SomeData>();
        foreach (string line in contentLines)
        {
            string[] words = line.Split(',');
            someDB.Add(new SomeData(words[0], words[1]));
        }

        SomeDataBase db = new SomeDataBase(someDB.ToArray());

        JsonSerializer serializer = new JsonSerializer();
        serializer.Formatting = Formatting.Indented;

        using (StreamWriter sw = new StreamWriter(PATH))
        using (JsonWriter writer = new JsonTextWriter(sw))
        {
            serializer.Serialize(writer, db);
        }
    }
}
