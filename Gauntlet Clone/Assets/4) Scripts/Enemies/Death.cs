using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public int damage = 2;
    public float delay = 0.1f;
    public int maxHealthSteal = 200;
    public int totalHealthStolen = 0;

    private void Start()
    {
        totalHealthStolen = 0;
        InvokeRepeating("DeathTouch", delay, delay);
    }

    public void DeathTouch()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1.1f))
        {
            if (hit.collider.CompareTag("Player"))
            {
                hit.collider.gameObject.GetComponent<Adventurer>().TakeDamage(damage);
                totalHealthStolen += damage;
            }
        }

        if (totalHealthStolen >= maxHealthSteal)
            Destroy(this.gameObject);
    }
}
