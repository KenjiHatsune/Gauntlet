using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure_PickUo : Adventurer
{
    public void Treasure()
    {
        Score += 100;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            gameObject.SetActive(false);
        }
    }
}
