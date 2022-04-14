using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum Direction
{
    none,
    up,
    upLeft,
    left,
    downLeft,
    down,
    downRight,
    right,
    upRight
}

public class Character : MonoBehaviour
{
    [Header("InputSystem")]
    protected PlayerControls _UIS;

    [Header("Basic Stats")]
    protected int Health = 0;
    [Tooltip("Reduces the damage taken from hostile attacks.")]
    [SerializeField] protected int Armor = 0;
    protected int Score = 0;
    [Tooltip("How long it takes to finish a 'move.'")]
    [SerializeField] protected float MoveTime = 2f;
    protected float _sensitivity = 0.4f;
    protected bool visible = true;

    [Header("Inventory")]
    protected int Keys = 0;
    protected int MagicPotions = 0;

    [Header("Attacks")]
    [Tooltip("Projectile of player's attack.")]
    [SerializeField] protected GameObject AttackPrefab;
    [Tooltip("Damage dealt by each attack.")]
    [SerializeField] protected int AttackDamage = 1;
    [Tooltip("Speed that the projectile moves.")]
    [SerializeField] protected float ProjectileSpeed = 2.5f;
    [Tooltip("Time between each attack.")]
    [SerializeField] protected float AttackDelay = 1f;
    protected bool AttackReady = true;

    [Header("Skills")]
    [Tooltip("Cooldown for class skill.")]
    [SerializeField] protected float SkillDelay = 30f;
    protected bool SkillReady = true;

    [Header("Utility Functions")]
    protected bool _moving;
    protected Rigidbody _RigBod;
    protected Direction currentDirection = Direction.none;
    protected Vector3 startPos;
    protected Vector3 endPos;
    protected float _moveTimePassed;
    protected float _attackTimePassed;
    protected float _skillTimePassed;

    protected void Start()
    {
        //Setting up player controls.
        _UIS = new PlayerControls();
        _UIS.Enable();

        //Getting and Setting up RigidBody.
        _RigBod = GetComponent<Rigidbody>();
        if (_RigBod == null)
            _RigBod = gameObject.AddComponent<Rigidbody>();
        _RigBod.useGravity = false;
        _RigBod.constraints = RigidbodyConstraints.FreezeRotation;

        startPos = transform.position;
        endPos = transform.position;

        StartCoroutine(PlayerMovement());
    }

    protected void FixedUpdate()
    {
        Move();
    }

    protected void Attack(InputAction.CallbackContext context)
    {
        //Returning if action is not performed or attack is not ready.
        if (!context.performed || !AttackReady) return;

        GameObject projectile = Instantiate(AttackPrefab, transform.position, transform.rotation); 
        
        AttackReady = false;
        StartCoroutine("AttackCooldown");
    }

    protected void UsePotion(InputAction.CallbackContext context)
    {
        //Ensuring the action only happens once and that the player has a Potion to use.
        if (!context.performed || MagicPotions <= 0) return;

        //Using Potion.
    }

    protected bool UseKey()
    {
        if (Keys >= 0)
        {
            Keys--;
            return true;
        }

        else
            return false;
    }

    //This translates the player's inputs into motion.
    public void Move()
    {
        //If the player is currently moving, reject input.
        if (_moving)
            return;

        Vector2 temp = _UIS.Player.Move.ReadValue<Vector2>();

        //Returning if no input.
        if (temp == Vector2.zero)
            currentDirection = Direction.none;

        //Determining which direction the player wants to go.
        else if (temp.y >= _sensitivity)
        {
            if (temp.x >= _sensitivity)
                currentDirection = Direction.upRight;
            else if (temp.x <= -_sensitivity)
                currentDirection = Direction.upLeft;

            else
                currentDirection = Direction.up;
        }
        else if (temp.y <= -_sensitivity)
        {
            if (temp.x >= _sensitivity)
                currentDirection = Direction.downRight;
            else if (temp.x <= -_sensitivity)
                currentDirection = Direction.downLeft;

            else
                currentDirection = Direction.down;
        }
        else if (temp.x >= _sensitivity)
            currentDirection = Direction.right;
        else if (temp.x <= -_sensitivity)
            currentDirection = Direction.left;
    }

    //This checks to make sure the player is not trying to walk through a wall.
    protected bool CheckWalls()
    {
        Ray LookingDirection = new Ray(transform.position, Vector3.up);
        RaycastHit hit;

        switch (currentDirection)
        {
            case Direction.none:
                return false;
            case Direction.up:
                LookingDirection = new Ray(transform.position, Vector3.forward);
                break;
            case Direction.upLeft:
                LookingDirection = new Ray(transform.position, Vector3.forward + Vector3.left);
                endPos = transform.position + Vector3.forward + Vector3.left;
                break;
            case Direction.left:
                LookingDirection = new Ray(transform.position, Vector3.left);
                endPos = transform.position + Vector3.left;
                break;
            case Direction.downLeft:
                LookingDirection = new Ray(transform.position, Vector3.back + Vector3.left);
                endPos = transform.position + Vector3.back + Vector3.left;
                break;
            case Direction.down:
                LookingDirection = new Ray(transform.position, Vector3.back);
                endPos = transform.position + Vector3.back;
                break;
            case Direction.downRight:
                LookingDirection = new Ray(transform.position, Vector3.back + Vector3.right);
                endPos = transform.position + Vector3.back + Vector3.right;
                break;
            case Direction.right:
                LookingDirection = new Ray(transform.position, Vector3.right);
                endPos = transform.position + Vector3.right;
                break;
            case Direction.upRight:
                LookingDirection = new Ray(transform.position, Vector3.forward + Vector3.right);
                endPos = transform.position + Vector3.forward + Vector3.right;
                break;

            default:
                Debug.LogError("currentDirection in Character is an invalid value. Doing nothing till fixed.");
                break;
        }

        //If something is hit, the player cannot move this direction.
        if (Physics.Raycast(LookingDirection, out hit, 1f))
            return false;

        else
            return true;
    }

    //This handles the actual movement of the player character.
    protected IEnumerator PlayerMovement()
    {
        while (true)
        {
            _moveTimePassed = 0f;

            //Verifying the player can move in this direction.
            if (CheckWalls())
            {
                switch (currentDirection)
                {
                    case Direction.none:
                        startPos = transform.position;
                        endPos = transform.position;
                        break;
                    case Direction.up:
                        startPos = transform.position;
                        endPos = transform.position + Vector3.forward;
                        break;
                    case Direction.upLeft:
                        startPos = transform.position;
                        endPos = transform.position + Vector3.forward + Vector3.left;
                        break;
                    case Direction.left:
                        startPos = transform.position;
                        endPos = transform.position + Vector3.left;
                        break;
                    case Direction.downLeft:
                        startPos = transform.position;
                        endPos = transform.position + Vector3.back + Vector3.left;
                        break;
                    case Direction.down:
                        startPos = transform.position;
                        endPos = transform.position + Vector3.back;
                        break;
                    case Direction.downRight:
                        startPos = transform.position;
                        endPos = transform.position + Vector3.back + Vector3.right;
                        break;
                    case Direction.right:
                        startPos = transform.position;
                        endPos = transform.position + Vector3.right;
                        break;
                    case Direction.upRight:
                        startPos = transform.position;
                        endPos = transform.position + Vector3.forward + Vector3.right;
                        break;

                    default:
                        Debug.LogError("currentDirection in Character is an invalid value. Doing nothing till fixed.");
                        break;
                }

                while (transform.position != endPos)
                {
                    _moving = true;

                    _moveTimePassed += Time.fixedDeltaTime;
                    transform.position = Vector3.Lerp(startPos, endPos, _moveTimePassed / MoveTime);

                    yield return new WaitForFixedUpdate();
                }

                _moving = false;
            }

            yield return new WaitForFixedUpdate();
        }
    }

    //This causes the player to slowly die as time passes by. They lose 1 HP each second.
    protected IEnumerator FadeAway()
    {
        while (Health > 0)
        {
            Health--;
            yield return new WaitForSeconds(1f);
        }
    }

    protected IEnumerator AttackCooldown()
    {
        _attackTimePassed = AttackDelay;

        while (_attackTimePassed > 0)
        {
            _attackTimePassed -= Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }

        AttackReady = true;
        StopCoroutine("AttackCooldown");
    }
    
    //This keeps track of the player's skill cooldown. When complete, it will allow the player to use the skill again.
    protected IEnumerator SkillCooldown()
    {
        //Setting skill cooldown timer.
        _skillTimePassed = SkillDelay;

        while (_skillTimePassed > 0)
        {
            _skillTimePassed--;
            yield return new WaitForSeconds(1f);
        }

        SkillReady = true;
        StopCoroutine("SkillCooldown");
    }
}
