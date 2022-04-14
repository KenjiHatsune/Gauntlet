using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grunt : BaseEnemy
{
    
    // Start is called before the first frame update
    void Start()
    {
        health = 2;
        speed = 2;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        DestroyEnemey();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "")
        {
            health -= 1;
        }
        if (other.gameObject.tag == "")
        {
            health -= 1;
        }
        if (other.gameObject.tag == "")
        {
            health -= 1;
        }
        if (other.gameObject.tag == "")
        {
            health -= 1;
        }
    }
    public void DestroyEnemey()
    {
        if(health == 0)
        {
            if(this.gameObject.tag == "Grunt")
            {
                this.gameObject.SetActive(false);
            }
        }
    }
    public void ClubAttack()
    {

    }
}
