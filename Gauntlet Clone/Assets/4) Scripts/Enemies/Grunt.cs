using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grunt : MonoBehaviour
{
    public int damage = 8;
    public float delay = 1.5f;

    private void Start()
    {
        InvokeRepeating("ClubAttack", delay, 1.5f);
    }

    public void ClubAttack()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1.1f))
        {
            if (hit.collider.CompareTag("Player"))
                hit.collider.gameObject.GetComponent<Adventurer>().TakeDamage(damage);
        }
    }
}
