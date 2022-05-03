using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    [Header("InputSystem")]
    protected Adventurer _playerControlled;
    protected PlayerControls _UIS;

    private static int _charactersMade = 0;

    [Header("PlayerControlledCharacters")]
    [SerializeField] private List<GameObject> _playerCharacters;
    private GameObject _character;
    private CharacterClass _characterClass;

    private void Start()
    {
        _UIS = new PlayerControls();
        _UIS.Enable();

        _character = Instantiate(_playerCharacters[_charactersMade], transform.position, transform.rotation);

        //Connecting Inputs and Syncing Functions
        _playerControlled = _character.GetComponent<Adventurer>();
        _characterClass = _playerControlled.CharClass;

        _charactersMade++;
        _charactersMade %= _playerCharacters.Count;
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        Vector2 temp = _UIS.Player.Move.ReadValue<Vector2>();
        _playerControlled.Move(temp);
    }

    public void Attack(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        Debug.Log("Attack Done.");
        _playerControlled.Attack();
    }
}
