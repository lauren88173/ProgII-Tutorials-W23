using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Behaviour : MonoBehaviour
{
    int _playerHealth = 28;
    bool _damagedByEnemy;

    //Audio mamanger


    [System.Serializable] 
    public class Inventory
    {
        public int coin;
    }
    [SerializeField] Inventory inventory = new Inventory();

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerHealth < 1)
        {
            PlayerDeath();
            FindObjectOfType<AudioManager>().Play("Player_Dies");
        }
    }

    public int GetHealth()
    {
        return _playerHealth;
    }
    public void DamagedByEnemy(int damage)
    {
        _playerHealth -= damage;
    }

    public void PlayerDeath()
    {
        Destroy(gameObject);
       
    }

    public void DamagePlayer(int damage)
    {
        _playerHealth -= damage;
    }
    public void AddCoin()
    {
        Debug.Log("Coin added to loot!");
        inventory.coin++;
    }
    public void AddHealth()
    {
        Debug.Log("Player health recovered!");
        _playerHealth++;
    }
}
