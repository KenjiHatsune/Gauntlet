using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : MonoBehaviour
{
    public int damage = 10;
    public int scoreDamage = 25;
    public GameObject treasureDrop;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<Adventurer>().TakeDamage(damage);
            other.GetComponent<Adventurer>().Score -= scoreDamage;
            UIManager.instance.UpdatePlayerData(other.GetComponent<Adventurer>().Agent.CharacterControlled);
            transform.position = transform.position - (transform.forward * 2.5f);
        }
    }

    private void OnDestroy()
    {
        Instantiate<GameObject>(treasureDrop, transform.position, transform.rotation);
    }
}
