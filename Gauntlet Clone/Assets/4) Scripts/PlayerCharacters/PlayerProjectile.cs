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
    public bool DamageDropOff = false;
    public int DamageDropOffAmount = 1;
    private float _damageDropOffTime = 2.5f;
    [Tooltip("How long the projectile lives for.")]
    public float LifeSpan = 5f;

    private void Start()
    {
        if (DamageDropOff)
        {
            _damageDropOffTime = LifeSpan / 2;

            Invoke("DamageDrop", _damageDropOffTime);
        }

        Destroy(this.gameObject, LifeSpan);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player") && !other.CompareTag("Attack") && other.gameObject.layer != LayerMask.NameToLayer("PlayerSpecificWall"))
            Destroy(this.gameObject);
    }

    private void DamageDrop()
    {
        Damage -= DamageDropOffAmount;

        //Destroying attack if it cannot deal damage, or if it will heal the enemy.
        if (Damage <= 0)
            Destroy(this.gameObject);
    }
}
