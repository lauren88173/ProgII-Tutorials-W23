using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Behaviour : MonoBehaviour
{
    public enum CoinType
    {
        GOLD,
        HEALTH

    }

    public CoinType rewardType;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            FindObjectOfType<AudioManager>().Play("Coin_Pickedup");

            //for distinguishing coin type
            switch (rewardType)
            {
                case CoinType.GOLD: 
                  FindObjectOfType<Player_Behaviour>().AddCoin();
                    break;

                case CoinType.HEALTH:
                    FindObjectOfType<Player_Behaviour>().AddHealth();
                    break;
            }
        }
    }

    
}
