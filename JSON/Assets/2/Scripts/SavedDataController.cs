using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using System;

public class SavedDataController : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    private const string PATH = @"Assets\2\Resources\SoundData.txt";
    VolumsBaseJSON Volum;

    void Start()
    {
        Volum = new VolumsBaseJSON();

        if (File.Exists(PATH) == false)
        {
            File.Create(PATH);
            SaveVolToJSON();
        }
        else
        {
            LoadVolFromJSON();
        }
    }
    void Update()
    {
        SaveVolToJSON();
    }

    public void LoadVolFromJSON()
    {
        string jsonStr = File.ReadAllText(PATH);
        Volum = JsonUtility.FromJson<VolumsBaseJSON>(jsonStr);
        audioSource.volume = Volum.AudioVolum;
    }

    public void SaveVolToJSON()
    {
        Volum.AudioVolum = audioSource.volume;
        string volumeStr = JsonUtility.ToJson(Volum);
        File.WriteAllText(PATH, volumeStr);
    }
}

[Serializable]
public class VolumsBaseJSON
{
    public float AudioVolum;
}