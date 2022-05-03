using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ElvenOne : Adventurer
{
    [Header("Elven Settings")]
    [SerializeField] private float BonusProjectileSpeed;
    [SerializeField] private float BonusMoveSpeed;

    public void TrueSight(InputAction.CallbackContext context)
    {
        if (SkillReady)
        {


            StartCoroutine("SkillCooldown");
        }
    }
}
