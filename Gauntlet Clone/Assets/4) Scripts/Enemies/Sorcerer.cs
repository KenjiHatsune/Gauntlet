using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sorcerer : MonoBehaviour
{
    public int damage = 5;
    public float visibleTime = 2.5f;
    public float invisibleTime = 1.5f;
    private Material material;
    private Collider collider;
    private Color visibleMode;
    private Color invisibleMode;

    private void Start()
    {
        material = gameObject.GetComponent<Renderer>().material;
        collider = gameObject.GetComponent<BoxCollider>();
        visibleMode = material.color;
        invisibleMode = material.color;
        invisibleMode.a = 0;
        StartCoroutine(Flash());
    }

    private IEnumerator Flash()
    {
        while (true)
        {
            yield return new WaitForSeconds(visibleTime);

            material.color = invisibleMode;
            collider.enabled = false;

            yield return new WaitForSeconds(invisibleTime);

            material.color = visibleMode;
            collider.enabled = true;

            yield return new WaitForFixedUpdate();
        }
    }
}
