using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonGen : MonoBehaviour
{
    public float delay = 1f;
    public float StartTime = 3f;
    public GameObject Demon;
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
        Instantiate(Demon, transform.position, transform.rotation, transform);
    }
}
