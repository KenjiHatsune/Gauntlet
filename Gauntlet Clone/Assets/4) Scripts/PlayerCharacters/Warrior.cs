using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Warrior : Adventurer
{

    public void Cleave(InputAction.CallbackContext context)
    {
        if (context.performed && SkillReady)
        {
            for (int index = 0; index < 3; index++)
            {
                GameObject projectile = Instantiate(AttackPrefab, transform.position, transform.rotation);
                switch (index)
                {
                    case 0:
                        projectile.GetComponent<Rigidbody>().velocity = (transform.forward * ProjectileSpeed);
                        break;
                    case 1:
                        projectile.GetComponent<Rigidbody>().velocity = ((transform.forward - transform.right) * ProjectileSpeed);
                        break;
                    case 2:
                        projectile.GetComponent<Rigidbody>().velocity = ((transform.forward + transform.right) * ProjectileSpeed);
                        break;
                    default:
                        break;
                }

                projectile.GetComponent<PlayerProjectile>().DamageDropOff = DamageDropOff;
                projectile.GetComponent<PlayerProjectile>().DamageDropOffAmount = DamageDropOffAmount;
                projectile.GetComponent<PlayerProjectile>().LifeSpan = ProjectileLifeSpan;
            }

            StartCoroutine("SkillCooldown");
        }
    }
}
