using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lobber : MonoBehaviour
{
    public int damage = 3;
    public float minThrowPower;
    public float maxThrowPower;
    public float delay = 1f;
    public GameObject projectile;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Throw", delay, 1.5f);
    }

    public void Throw()
    {
        Debug.Log("Shooting");
        GameObject shoot = Instantiate(projectile, transform.position, transform.rotation);
        shoot.GetComponent<LobberProjectile>().damage = damage;
        shoot.GetComponent<Rigidbody>().AddForce((transform.forward + transform.up * 5) * Random.Range(minThrowPower, maxThrowPower), ForceMode.Impulse);
    }
}
