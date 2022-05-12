using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food_PickUp : Adventurer
{
    public void FoodPick()
    {
        Health += 100;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            gameObject.SetActive(false);
        }
    }
}
