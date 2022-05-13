using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobberGen : MonoBehaviour
{
    public float delay = .1f;
    public float StartTime = 3f;
    public GameObject Lobber;
    public GameObject spawn;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", delay, StartTime);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Spawn()
    {
        Instantiate(Lobber, spawn.transform.position, spawn.transform.rotation);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Attack")
        {
            gameObject.SetActive(false);
        }
    }
}
