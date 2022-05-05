using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private float[] _playerPos_x;
    private float[] _playerPos_z;
    private Vector3 _shadowPos;
    [SerializeField] private GameObject[] _stalkedTargets;

    private void Start()
    {
        RefreshPlayerList();

        Application.targetFrameRate = 60;
    }

    public void RefreshPlayerList()
    {
        _stalkedTargets = GameObject.FindGameObjectsWithTag("Player");
        _playerPos_x = new float[_stalkedTargets.Length];
        _playerPos_z = new float[_stalkedTargets.Length];
    }

    private void FixedUpdate()
    {
        FindCenter();

        //Calibrating Camera Position
        _shadowPos.y += 30f;

        //Adjusting Camera Position
        transform.position = Vector3.Lerp(transform.position, _shadowPos, 0.25f);
    }

    private void FindCenter()
    {
        //Getting the x and z positions of all players.
        for (int index = 0; index < _stalkedTargets.Length; index++)
        {
            _playerPos_x[index] = _stalkedTargets[index].transform.position.x;
            _playerPos_z[index] = _stalkedTargets[index].transform.position.z;
        }

        //Calculating the Min-Max positions of the player's positions to find the center.
        float minX = Mathf.Min(_playerPos_x);
        float maxX = Mathf.Max(_playerPos_x);
        float minZ = Mathf.Min(_playerPos_z);
        float maxZ = Mathf.Max(_playerPos_z);

        //Calculating the Point on the map where the camera should be.
        _shadowPos = Vector3.zero;
        _shadowPos.x = minX + (Mathf.Abs(maxX - minX) / 2);
        _shadowPos.z = minZ + (Mathf.Abs(maxZ - minZ) / 2);
    }
}
