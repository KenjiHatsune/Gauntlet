using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : BaseEnemy
{
    // Start is called before the first frame update
    void Start()
    {
        health = 200;
        speed = 4;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
  
    public void DrainHealth()
    {

    }
}
