using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    [Header("Variables for movement")]
    public int speed;
    public int health;
    public float range = 10f;
    public float limitRange = 5f;
    public float damage;
   public GameObject player;
    //public Rigidbody rgbd;
   
    // Start is called before the first frame update
    void Start()
    {
        //rgbd = GetComponent<Rigidbody>();
        
        
            player = GameObject.FindGameObjectWithTag("Player");
        
       
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
       // player = GameObject.FindWithTag("Player").transform;
    }
    
    public void Move()
    {
        transform.LookAt(player.transform.position);

        transform.position += transform.forward * speed * Time.deltaTime;
        
    }
}
