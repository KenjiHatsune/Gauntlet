using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Real_Potion : MonoBehaviour
{
    Renderer view;
    private new GameObject[] gameObject;
    public void Start()
    {
        view = GetComponent<Renderer>();
    }
    public void DestroyEnem()
    {
        if (view.isVisible)
        {
            gameObject = GameObject.FindGameObjectsWithTag("Enemy");
            for (int i = 0; i < gameObject.Length; i++)
            {
                Destroy(gameObject[i]);
            }
        }
    }
    public void UsePotion()
    {
        DestroyEnem();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            DestroyEnem();
        }
    }
}
