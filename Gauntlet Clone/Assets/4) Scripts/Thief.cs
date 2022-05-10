using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : BaseEnemy
{
    private Adventurer character;
    public float pointsTaken;
    public GameObject pointDrop;
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
        if (other.gameObject.tag == "Attack")
        {
            health--;
            Instantiate(pointDrop);
        }
        if (other.gameObject.tag == "Player")
        {
            character.TakeDamage(8);
           
        }
    }
    public void DestroyEnemey()
    {
        if (health == 0)
        {
            if (this.gameObject.tag == "Thief")
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}
