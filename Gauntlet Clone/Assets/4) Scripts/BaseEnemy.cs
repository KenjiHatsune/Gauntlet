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
    public Transform player;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    
    public void Move()
    {
        transform.LookAt(player);
       
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
