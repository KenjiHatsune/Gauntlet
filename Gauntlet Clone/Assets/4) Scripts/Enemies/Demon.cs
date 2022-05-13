using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demon : MonoBehaviour
{
    public int rangeDamage = 10;
    public float rangedelay = 1.25f;
    public float rangeStartTime = 1.25f;
    public float ProjectileSpeed = 5f;
    public GameObject projectile;

    public int meleeDamage = 8;
    public float meleeDelay = 1.5f;

    private void Start()
    {
        InvokeRepeating("ClubAttack", meleeDelay, meleeDelay);
        InvokeRepeating("FireBall", rangedelay, rangeStartTime);
    }

    public void ClubAttack()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1.1f))
        {
            if (hit.collider.CompareTag("Player"))
                hit.collider.gameObject.GetComponent<Adventurer>().TakeDamage(meleeDamage);
        }
    }

    public void FireBall()
    {
        GameObject shoot = Instantiate(projectile, transform.position, transform.rotation);
        shoot.GetComponent<Rigidbody>().AddForce(transform.forward * ProjectileSpeed, ForceMode.Impulse);
        shoot.GetComponent<LobberProjectile>().damage = rangeDamage;
    }
}
