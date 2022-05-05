using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterSwitcher : Singleton<CharacterSwitcher>
{
    private int _characterMade;
    [SerializeField] private List<GameObject> _AdventurersOfLight;
    private PlayerInputManager _manager;

    private void Start()
    {
        _manager = GetComponent<PlayerInputManager>();
        if (_manager == null)
            _manager = gameObject.AddComponent<PlayerInputManager>();
        _manager.playerPrefab = _AdventurersOfLight[_characterMade];
    }

    public void SwitchNextSpawnedCharacter(PlayerInput input)
    {
        _characterMade++;
        _characterMade %= _AdventurersOfLight.Count;
        _manager.playerPrefab = _AdventurersOfLight[_characterMade];
    }
}
