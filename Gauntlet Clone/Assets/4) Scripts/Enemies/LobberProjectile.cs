using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobberProjectile : MonoBehaviour
{
    public int damage = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<Adventurer>().TakeDamage(damage);
        }

        if (!other.CompareTag("Enemy"))
            Destroy(this.gameObject);
    }
}
