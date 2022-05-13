using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManagerManager : MonoBehaviour
{
    public PlayerInputManager InputManager;
    public GameObject[] PossiblePlayers = new GameObject[4];
    private int _playerNum;

    public void SwitchPrefab()
    {
        _playerNum++;
        _playerNum %= 4;
        InputManager.playerPrefab = PossiblePlayers[_playerNum];
    }
}
