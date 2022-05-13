using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : Singleton<CameraFollow>
{
    private float[] _playerPos_x;
    private float[] _playerPos_z;
    public float CameraHeight = 30f;
    private Vector3 _shadowPos;
    [SerializeField] private GameObject[] _stalkedTargets;
    [SerializeField] private float _xRgtBound, _xLftBound, _zTopBound, _zBotBound;
    public float RgtBound
    {
        get { return _xRgtBound; }
        set { _xRgtBound = value; }
    }
    public float LftBound
    {
        get { return _xLftBound; }
        set { _xLftBound = value; }
    }
    public float TopBound
    {
        get { return _zTopBound; }
        set { _zTopBound = value; }
    }
    public float BotBound
    {
        get { return _zBotBound; }
        set { _zBotBound = value; }
    }

    private void Start()
    {
        RefreshPlayerList();

        FindBoundaries();

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
        _shadowPos.y += CameraHeight;

        //Adjusting Camera Position
        transform.position = Vector3.Lerp(transform.position, _shadowPos, 0.25f);

        FindBoundaries();
    }

    private void FindBoundaries()
    {
        RgtBound = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, - Camera.main.transform.position.y)).x;
        LftBound = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, -Camera.main.transform.position.y)).x;
        TopBound = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, -Camera.main.transform.position.y)).z;
        BotBound = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, -Camera.main.transform.position.y)).z;
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
