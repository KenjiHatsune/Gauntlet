using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntGen : MonoBehaviour
{
    public float delay = 1f;
    public float StartTime = 3f;
    public GameObject Grunt;
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
        Instantiate(Grunt,transform.position,transform.rotation);
    }
}
