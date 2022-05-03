using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Wizard : Adventurer
{

    public void ElementalShift(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            ///Switching Element.\\\
            int temp = (int)AttackElement;
            temp++;
            temp = temp % 7;

            if (temp == 0)
                temp++;

            AttackElement = (Element)temp;

            ///Exploding Wizard\\\
            if (SkillReady)
            {
                float tempSpeed = ProjectileSpeed / 2;
                for (int index = 0; index < 8; index++)
                {
                    GameObject projectile = Instantiate(AttackPrefab, transform.position, transform.rotation);
                    switch (index)
                    {
                        case 0:
                            projectile.GetComponent<Rigidbody>().velocity = (transform.forward * tempSpeed);
                            break;
                        case 1:
                            projectile.GetComponent<Rigidbody>().velocity = ((transform.forward - transform.right) * tempSpeed);
                            break;
                        case 2:
                            projectile.GetComponent<Rigidbody>().velocity = ((transform.forward + transform.right) * tempSpeed);
                            break;
                        case 3:
                            projectile.GetComponent<Rigidbody>().velocity = ((transform.right) * tempSpeed);
                            break;
                        case 4:
                            projectile.GetComponent<Rigidbody>().velocity = ((-transform.right) * tempSpeed);
                            break;
                        case 5:
                            projectile.GetComponent<Rigidbody>().velocity = ((-transform.forward + transform.right) * tempSpeed);
                            break;
                        case 6:
                            projectile.GetComponent<Rigidbody>().velocity = ((-transform.forward - transform.right) * tempSpeed);
                            break;
                        case 7:
                            projectile.GetComponent<Rigidbody>().velocity = ((-transform.forward) * tempSpeed);
                            break;
                        default:
                            break;
                    }

                    projectile.GetComponent<PlayerProjectile>().LifeSpan = 0.4f;
                }

                StartCoroutine("SkillCooldown");
            }
        }
    }
}
