using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Player Panel Components")]
    public GameObject[] PlayerStatus = new GameObject[4];
    public GameObject[] PlayerCredit = new GameObject[4];

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject item in PlayerStatus)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
