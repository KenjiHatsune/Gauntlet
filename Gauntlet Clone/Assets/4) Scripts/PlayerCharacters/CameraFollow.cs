using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 _shadowPos;
    private GameObject _stalkedTarget;

    private void Start()
    {
        if (_stalkedTarget == null)
            _stalkedTarget = GameObject.FindGameObjectWithTag("Player");

        Application.targetFrameRate = 60;
    }

    private void FixedUpdate()
    {
        _shadowPos = _stalkedTarget.transform.position;
        _shadowPos.y += 6f;
        _shadowPos.z -= 2f;

        transform.position = Vector3.Lerp(transform.position, _shadowPos, 0.25f);
    }
}
