using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Valkyrie : Adventurer
{
    [Header("Valkyrie Settings")]
    [SerializeField] private int BonusArmor = 2;
    [SerializeField][Range(0.25f, 0.75f)] private float GFPercentage = 0.5f;
    private float GuardianFieldDuration = 5f;

    // Start is called before the first frame update
    void Start()
    {
        //Adding bonus armor to character's armor level.
        Armor += BonusArmor;

        //Calculating the persentage of cooldown time Guardian Field is active.
        GuardianFieldDuration = SkillDelay * GFPercentage;
    }

    public void GuardianField(InputAction.CallbackContext context)
    {
        if (context.performed && SkillReady)
        {
            StartCoroutine(Protection());

            StartCoroutine("SkillCooldown");
        }
    }

    private IEnumerator Protection()
    {
        vulnerable = false;
        Debug.Log("Valkyrie Invincible");

        yield return new WaitForSeconds(GuardianFieldDuration);

        Debug.Log("Valkyrie Vulnerable");
        vulnerable = true;
    }
}
