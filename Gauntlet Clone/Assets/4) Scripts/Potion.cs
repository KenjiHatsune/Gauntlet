using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    private new  GameObject[] gameObject;
   public void DestroyEnemies()
    {
        gameObject = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < gameObject.Length; i++)
        {
            Destroy(gameObject[i]);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            DestroyEnemies();
        }
    }
}
