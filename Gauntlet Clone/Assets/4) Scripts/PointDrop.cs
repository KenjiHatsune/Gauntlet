using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointDrop : Adventurer
{
    public int PointsAmount = 500;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Score += PointsAmount;
            
        }
    }
}
