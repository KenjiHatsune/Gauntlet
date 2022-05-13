using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WizardInputHandler : Singleton<WizardInputHandler>
{
    [Header("InputSystem")]
    protected static Adventurer _adventurer;
    private PlayerControls _UIS;
    private Vector3 _playerSpawn;

    private int _characterControlled = 1;
    public int CharacterControlled
    {
        get { return _characterControlled; }
    }
    private bool _dualSpawnFix = false;

    [Header("PlayerControlledCharacters")]
    [SerializeField] private GameObject _spawnedCharacter;
    private static GameObject _character;
    public GameObject Character
    {
        get { return _character; }
    }

    private void Start()
    {
        ///Normal Operations\\\
        _UIS = new PlayerControls();
        _UIS.Enable();

        //Naming this object.
        this.gameObject.name = "PlayerController_" + _characterControlled.ToString();
    }

    public void NewPlayer()
    {
        if (_character)
            KillPlayer();

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
        _character = Instantiate(_spawnedCharacter, _playerSpawn, transform.rotation, transform);

        //Connecting Inputs and Syncing Functions
        _adventurer = _character.GetComponent<Adventurer>();
        UIManager.instance.AddPlayer(_adventurer, _characterControlled);
        _dualSpawnFix = true;

        //Telling Camera to Follow
        Camera.main.GetComponent<CameraFollow>().AddPlayer(_character, _characterControlled);
    }

    public void AddCredit(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        UIManager.instance.Credits++;
        UIManager.instance.UpdateCredits();
    }

    public void UseCredit(InputAction.CallbackContext context)
    {
        if (context.canceled && UIManager.instance.Credits >= 1)
        {
            //For some reason, both the prefab and the one in the scene are being used. I blame the PlayerInputManager.
            //  Atleast making these Singletons prevent it from throwing errors and spawning tons of copies.

            //If Player is alive, increasing HP.
            if (_dualSpawnFix)
            {
                _adventurer = _character.GetComponent<Adventurer>();
                _adventurer.Health += 325;
                UIManager.instance.UpdatePlayerData(_characterControlled);

                //Consuming Credit
                UIManager.instance.Credits--;
                UIManager.instance.UpdateCredits();
            }
            //If Player is dead, spawning new Player.
            else
            {
                NewPlayer();

                //Consuming Credit
                UIManager.instance.Credits--;
                UIManager.instance.UpdateCredits();
            }
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
        Destroy(_character);
        UIManager.instance.RemovePlayer(_characterControlled);
        _dualSpawnFix = false;
    }
}
