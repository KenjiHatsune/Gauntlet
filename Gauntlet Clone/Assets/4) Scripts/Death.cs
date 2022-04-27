using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : BaseEnemy
{
    // Start is called before the first frame update
    void Start()
    {
        //health = 200;
        speed = 4;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
  
    public void DrainHealth()
    {

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
