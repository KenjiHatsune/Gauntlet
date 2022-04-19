using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : BaseEnemy
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
            gameObject.SetActive(false);
           // character.TakeDamage(20);
        }
    }
}
