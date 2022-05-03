using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sorcerer : BaseEnemy
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
        DestroyEnemey();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            character.TakeDamage(8);
        }
        if (other.gameObject.tag == "Attack")
        {
            health--;
        }
    }
    public void DestroyEnemey()
    {
        if (health == 0)
        {
            if (this.gameObject.tag == "Sorcerer")
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}
