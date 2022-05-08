using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : BaseEnemy
{
    private Adventurer character;
    // Start is called before the first frame update
    void Start()
    {
        health = 200;
        speed = 4;
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
            StartCoroutine("Drain", 3);
        }
        if (other.gameObject.tag == "Attack")
        {
            health--;
        }
    }
    IEnumerator Drain(int seconds)
    {
        yield return new WaitForSeconds(2);
        character.TakeDamage(10);
    }
    public void DestroyEnemey()
    {
        if (health == 0)
        {
            if (this.gameObject.tag == "Death")
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}
