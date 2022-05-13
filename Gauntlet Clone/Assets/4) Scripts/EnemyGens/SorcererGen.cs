using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SorcererGen : MonoBehaviour
{
    public float delay = 1f;
    public float StartTime = 3f;
    public GameObject Sorcerer;
    //public GameObject spawn;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", delay, StartTime);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Attack")
        {
            gameObject.SetActive(false);
        }
    }
    public void Spawn()
    {
        Instantiate(Sorcerer, transform.position, transform.rotation, transform);
    }
}
