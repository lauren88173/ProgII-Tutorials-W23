using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Behaviour : MonoBehaviour
{
    int _playerHealth = 28;
    bool _damagedByEnemy;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerHealth < 1)
        {
            PlayerDeath();
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
}
