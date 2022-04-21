using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grunt : BaseEnemy
{
    private Character character;
  
    // Start is called before the first frame update
    void Start()
    {
        //health = 2;
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
        if(other.gameObject.tag == "Attack")
        {
            health--;
        }
        if(other.gameObject.tag == "Player")
        {
            character.TakeDamage(2);
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
