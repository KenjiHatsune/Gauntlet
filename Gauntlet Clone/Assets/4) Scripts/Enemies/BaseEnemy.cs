using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    Ghost,      //Weak to Fire
    Grunt,      //Weak to Dark
    Demon,      //Weak to Light
    Lobber,     //Weak to Wind
    Sorcerer,   //Weak to Water
    Thief       //Weak to Earth
}

public class BaseEnemy : MonoBehaviour
{
    [Header("Variables for movement")]
    public float speed;
    public int health;
    public GameObject player;
    public EnemyType enemyType;
    private Rigidbody rb;
    private Vector3 movement = Vector3.zero;
    
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
            Move();
    }
    
    public void Move()
    {
        transform.LookAt(player.transform.position);
        movement = transform.forward * speed;
        rb.velocity = movement;
    }

    public void DamageEnemy(int damage, Element element)
    {
        switch (enemyType)
        {
            case EnemyType.Ghost:
                if (element == Element.Fire)
                    damage *= 2;
                break;
            case EnemyType.Grunt:
                if (element == Element.Dark)
                    damage *= 2;
                break;
            case EnemyType.Demon:
                if (element == Element.Light)
                    damage *= 2;
                break;
            case EnemyType.Lobber:
                if (element == Element.Wind)
                    damage *= 2;
                break;
            case EnemyType.Sorcerer:
                if (element == Element.Water)
                    damage *= 2;
                break;
            case EnemyType.Thief:
                if (element == Element.Earth)
                    damage *= 2;
                break;
            default:
                Debug.LogError("Unexpected form of elemental damage in BaseEnemy.");
                break;
        }

        health -= damage;

        if (health <= 0)
            Destroy(this.gameObject);
    }
}
