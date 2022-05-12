using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    [Header("InputSystem")]
    [SerializeField] protected Adventurer _adventurer;
    private PlayerControls _UIS;
    private Vector3 _playerSpawn;

    private static int _charactersMade = 0;

    [Header("PlayerControlledCharacters")]
    [SerializeField] private List<GameObject> _playerCharacters;
    [SerializeField] private GameObject _character;

    private void Start()
    {
        _UIS = new PlayerControls();
        _UIS.Enable();

        _playerSpawn = transform.position;
        _playerSpawn.y += 0.5f;

        _character = Instantiate(_playerCharacters[_charactersMade], _playerSpawn, transform.rotation);

        //Connecting Inputs and Syncing Functions
        _adventurer = _character.GetComponent<Adventurer>();

        //Telling Camera to Follow
        Camera.main.GetComponent<CameraFollow>().RefreshPlayerList();

        _charactersMade++;
        _charactersMade %= _playerCharacters.Count;
    }

    public void Move(InputAction.CallbackContext context)
    {
        if (context.performed)
            _adventurer.Move(context.ReadValue<Vector2>());
    }

    public void Attack(InputAction.CallbackContext context)
    {
        if (!context.performed || !_adventurer.AttackReady) return;
        
        //Attacking if Action is Performed.
        _adventurer.Attack();
    }

    public void UseSkill(InputAction.CallbackContext context)
    {
        if (!context.performed || !_adventurer.SkillReady) return;

        //Attacking if Action is Performed.
        _adventurer.UseSkill();
    }

    public void UsePotion(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        //Attacking if Action is Performed.
        _adventurer.UsePotion();
    }
}
