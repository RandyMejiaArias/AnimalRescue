using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayDataController : MonoBehaviour
{
    public GameObject player;
    public string saveFile;
    public PlayData playData = new PlayData();
    
    private void Awake() {
        saveFile = Application.dataPath + "/playData.json";
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.C))
            LoadData();
        
        if(Input.GetKeyDown(KeyCode.G))
            SaveData();
        
    }

    private void LoadData() {
        if(File.Exists(saveFile)) {
            string content = File.ReadAllText(saveFile);
            playData = JsonUtility.FromJson<PlayData>(content);

            Debug.Log("Posición Jugador: " + playData.playerPosition);

            player.transform.position = playData.playerPosition;
        }else {
            Debug.Log("No existe un archivo de guardado previo...");
        }
    }

    private void SaveData() {
        PlayData newData = new PlayData() {
            playerPosition = player.transform.position
        };

        string jsonObject = JsonUtility.ToJson(newData);
        File.WriteAllText(saveFile, jsonObject);
        Debug.Log("Archivo Guardado...");
    }
}
