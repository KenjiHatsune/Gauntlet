using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Element
{
    Physical,   //Default Damage
    Fire,       //Good Against Ghost
    Dark,       //Good Against Grunt
    Light,      //Good Against Demon
    Wind,       //Good Against Lobber
    Water,      //Good Against Sorcerer
    Earth       //Good Against Theives
}

public class PlayerProjectile : MonoBehaviour
{
    public Element AttackElement = Element.Physical;
    public int Damage = 2;
    [Tooltip("Does the damage drop off by the set amount through the attack?")]
    public bool DamageDropOff = false;
    public int DamageDropOffAmount = 1;
    private float _damageDropOffTime = 2.5f;
    [Tooltip("Does this projectile lock onto a target and move towards it?")]
    public bool Lockon = false;
    public float speed;
    public GameObject Target;
    [Tooltip("How long the projectile lives for.")]
    public float LifeSpan = 5f;

    private void Start()
    {
        if (Lockon)
        {
            //Finding possible targets.
            GameObject[] temp = GameObject.FindGameObjectsWithTag("Enemy");

            //Calibrating distance checks.
            float distance = Mathf.Infinity;
            float curDistance = Mathf.Infinity;

            //Comparing distance to target for each possible target and targeting closest one.
            foreach (GameObject item in temp)
            {
                curDistance = Vector3.Distance(item.transform.position, transform.position);
                if (curDistance < distance)
                {
                    distance = curDistance;
                    Target = item;
                }
            }
        }

        if (DamageDropOff)
        {
            _damageDropOffTime = LifeSpan / 2;

            Invoke("DamageDrop", _damageDropOffTime);
        }

        Destroy(this.gameObject, LifeSpan);
    }

    private void FixedUpdate()
    {
        if (Lockon)
        {
            speed = GetComponent<Rigidbody>().velocity.magnitude;
            Vector3 direction = (Target.transform.position - transform.position).normalized;
            direction *= speed;
            GetComponent<Rigidbody>().velocity = direction;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player") && !other.CompareTag("Attack"))
        {
            if (other.CompareTag("Enemy"))
            {
                other.GetComponent<BaseEnemy>().DamageEnemy(Damage, AttackElement);
            }
            Destroy(this.gameObject);
        }
    }

    private void DamageDrop()
    {
        Damage -= DamageDropOffAmount;

        //Destroying attack if it cannot deal damage, or if it will heal the enemy.
        if (Damage <= 0)
            Destroy(this.gameObject);
    }
}
