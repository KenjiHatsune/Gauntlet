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

    private int _characterControlled;
    public int CharacterControlled
    {
        get { return _characterControlled; }
    }
    private static int _charactersMade = 0;
    private static bool _dualSpawnFix = false;

    [Header("PlayerControlledCharacters")]
    [SerializeField] private List<GameObject> _playerCharacters;
    [SerializeField] private GameObject _character;

    private void Start()
    {
        //Ensuring only 4 players can exist. Executing Order 66.
        if (_charactersMade >= 4)
        {
            Destroy(this.gameObject);
            Destroy(this);
            return;
        }

        ///Normal Operations\\\

        //Setting Player Controlled Number and recording the fact the player is made.
        _characterControlled = _charactersMade;
        _charactersMade++;

        //Naming this object.
        this.gameObject.name = "PlayerController_" + _characterControlled.ToString();
    }

    public void NewPlayer()
    {
        //Moving Player to below the camera.
        _playerSpawn = Camera.main.transform.position;
        switch (_characterControlled)
        {
            case 0:
                break;
            case 1:
                _playerSpawn.x += 1f;
                _playerSpawn.z += 1f;
                break;
            case 2:
                _playerSpawn.x += 1f;
                _playerSpawn.z -= 1f;
                break;
            case 3:
                _playerSpawn.x -= 1f;
                _playerSpawn.z -= 1f;
                break;
            default:
                break;
        }
        _playerSpawn.y = 0.6f;

        //making a New Player.
        _character = Instantiate(_playerCharacters[_characterControlled], _playerSpawn, transform.rotation);

        //Connecting Inputs and Syncing Functions
        _adventurer = _character.GetComponent<Adventurer>();
        _adventurer.Agent = this;
        UIManager.instance.AddPlayer(_adventurer);

        //Telling Camera to Follow
        Camera.main.GetComponent<CameraFollow>().RefreshPlayerList();
    }

    public void AddCredit(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        UIManager.instance.Credits++;
        UIManager.instance.UpdateCredits();
    }

    public void UseCredit(InputAction.CallbackContext context)
    {
        if (!context.started)
            return;

        if (!_dualSpawnFix) _dualSpawnFix = true;

        else if (UIManager.instance.Credits >= 1)
        {
            //Consuming Credit
            UIManager.instance.Credits--;
            UIManager.instance.UpdateCredits();

            //If Player is alive, increasing HP.
            if (_character != null)
            {
                _adventurer.Health += 750;
                UIManager.instance.UpdatePlayerData(_characterControlled);
            }
            //If Player is dead, spawning new Player.
            else
                NewPlayer();
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        if (_adventurer == null) return;

        _adventurer.Move(context.ReadValue<Vector2>());
    }

    public void Attack(InputAction.CallbackContext context)
    {
        if (!context.performed || _adventurer == null || !_adventurer.AttackReady) return;
        
        //Attacking if Action is Performed.
        _adventurer.Attack();
    }

    public void UseSkill(InputAction.CallbackContext context)
    {
        if (!context.performed || _adventurer == null || !_adventurer.SkillReady) return;

        //Attacking if Action is Performed.
        _adventurer.UseSkill();
    }

    public void UsePotion(InputAction.CallbackContext context)
    {
        if (!context.performed || _adventurer == null) return;

        //Attacking if Action is Performed.
        _adventurer.UsePotion();
    }

    public void OrderUIUpdate()
    {
        UIManager.instance.UpdatePlayerData(_characterControlled);
    }

    public void KillPlayer()
    {
        UIManager.instance.RemovePlayer(_characterControlled);
    }
}
