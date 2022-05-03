using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lobber : BaseEnemy
{
    private Character character;
    public float delay = 1f;
    public float StartTime = 1f;
    public GameObject projectile;
    public float ProjectileSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        InvokeRepeating("Throw", delay, StartTime);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Attack")
        {
            health--;
        }
        if (other.gameObject.tag == "Player")
        {
            character.TakeDamage(2);
        }

    }
    public void Throw()
    {
       GameObject shoot = Instantiate(projectile, transform.position, transform.rotation);
        shoot.GetComponent<Rigidbody>().AddForce(transform.forward * ProjectileSpeed, ForceMode.Impulse);
        Destroy(shoot, 2f);
    }
    public void DestroyEnemey()
    {
        if (health == 0)
        {
            if (this.gameObject.tag == "Lobber")
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}
