using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demon : BaseEnemy
{
    private Adventurer character;
    public float delay = 1f;
    public float StartTime = 1f;
    public GameObject projectile;
    public float ProjectileSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        InvokeRepeating("FireBall", delay, StartTime);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        DestroyEnemey();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
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
            if (this.gameObject.tag == "Demon")
            {
                this.gameObject.SetActive(false);
            }
        }
    }
    public void FireBall()
    {
        GameObject shoot = Instantiate(projectile, transform.position, transform.rotation);
        shoot.GetComponent<Rigidbody>().AddForce(transform.forward * ProjectileSpeed, ForceMode.Impulse);
        Destroy(shoot, 2f);
    }
}
