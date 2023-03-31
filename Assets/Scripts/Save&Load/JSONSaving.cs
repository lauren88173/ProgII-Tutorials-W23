using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Events;
using System.Text;

public class JSONSaving : MonoBehaviour
{
    private Player_Behaviour playerBehaviour;


    void Start()
    {
        playerBehaviour = GameObject.FindObjectOfType<Player_Behaviour>();
    }

    void Save()
    {
        string saveGame = JsonUtility.ToJson(playerBehaviour.gameObject.transform.position);
        
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
