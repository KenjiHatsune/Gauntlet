using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demon : BaseEnemy
{
    //private Character character;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //character.takeDamage(8);
        }
    }
}
