using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Events;
using System.Text;

public class JSONSaving : MonoBehaviour
{
    private Player_Behaviour playerBehaviour;

    //Encrypting Save Data, below is the key. Dont have to call it KeyWord if I dont want it to be obvious
    private static readonly string keyWord = "1784573";

    void Start()
    {
        playerBehaviour = GameObject.FindObjectOfType<Player_Behaviour>();
    }

    void Save()
    {
        string saveGame = JsonUtility.ToJson(playerBehaviour.gameObject.transform.position);
        Encryption.EncryptSave()
        File.WriteAllText(Application.persistentDataPath + "/LaurensProgLab", saveGame);
        
    }

    void Load()
    {
        //If the file doesnt exist, leave the function/do nothing.
        if (!File.Exists(Application.persistentDataPath + "/LaurensProgLab"))
        {
            return; //can be at the end of line above without {} because the only thing within the if statement is a single line.
        }

        string saveGame = File.ReadAllText(Application.persistentDataPath + "/LaurensProgLab");
        Encryption.DecryptSave()
        playerBehaviour.gameObject.transform.position = JsonUtility.FromJson<Vector3>(saveGame);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Save();
            Debug.Log("GameSaved");
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            Load();
            Debug.Log("GameLoaded");
        }
    }


}
