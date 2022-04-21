using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sorcerer : BaseEnemy
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move(); 
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
