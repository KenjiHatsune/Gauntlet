using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostGen : MonoBehaviour
{
    public float delay = 1f;
    public float StartTime = 3f;
    public GameObject Ghost;
    //public GameObject spawn;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", delay, StartTime);
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
        Instantiate(Ghost, transform.position, transform.rotation);
    }
}
