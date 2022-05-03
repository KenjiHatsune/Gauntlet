using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : BaseEnemy
{
    private Adventurer character;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Attack")
        {
            health--;
        }
        if (other.gameObject.tag == "Player")
        {
            character.TakeDamage(8);
        }
    }
}
