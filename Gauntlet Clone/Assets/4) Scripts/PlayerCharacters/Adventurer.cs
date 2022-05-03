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

public enum CharacterClass
{
    Warrior,
    Wizard,
    Valkyrie,
    ElvenOne
}

public class Adventurer : MonoBehaviour
{
    [Header("Basic Stats")]
    protected int Health = 0;
    [Tooltip("Reduces the damage taken from hostile attacks.")]
    [SerializeField] protected int Armor = 0;
    protected int Score = 0;
    [Tooltip("How long it takes to finish a 'move.'")]
    [SerializeField] protected float MoveTime = 0.25f;
    protected float _sensitivity = 0.4f;
    protected bool visible = true;
    protected bool vulnerable = true;

    [Header("Inventory")]
    protected int Keys = 0;
    protected int MagicPotions = 0;

    [Header("Attacks")]
    [Tooltip("Projectile of player's attack.")]
    [SerializeField] protected GameObject AttackPrefab;
    [Tooltip("Element of Player's attack.")]
    [SerializeField] protected Element AttackElement;
    [Tooltip("Damage dealt by each attack.")]
    [SerializeField] protected int AttackDamage = 1;
    [Tooltip("Speed that the projectile moves.")]
    [SerializeField] protected float ProjectileSpeed = 10f;
    [Tooltip("Time between each attack.")]
    [SerializeField] protected float AttackDelay = 1f;
    [Tooltip("How long the projectile lives for.")]
    [SerializeField] protected float ProjectileLifeSpan = 5f;
    public bool AttackReady = true;

    [Header("Skills")]
    [Tooltip("Cooldown for class skill.")]
    [SerializeField] protected float SkillDelay = 5f;
    public bool SkillReady = true;

    [Header("Utility Functions")]
    protected bool _moving;
    protected Rigidbody _RigBod;
    protected Direction currentDirection = Direction.none;
    protected Vector3 startPos;
    protected Vector3 endPos;
    protected float _moveTimePassed;
    protected float _attackTimePassed;
    protected float _skillTimePassed;
    [SerializeField] protected LayerMask _wallLayer;

    [Header("Class")]
    [SerializeField] private CharacterClass _characterClass;
    public CharacterClass CharClass
    {
        get { return _characterClass; }
    }

    [Header("Warrior Settings")]
    [Tooltip("Controls whether or not the attack's damage drops off over time.")]
    [SerializeField] protected bool DamageDropOff = false;
    [Tooltip("Controls the amount the attack's damage drops once a quarter of it's lifetime passes.")]
    [SerializeField] protected int DamageDropOffAmount = 0;

    [Header("Valkyrie Settings")]
    [Tooltip("Extra armor from being a Valkyrie, further reducing damage.")]
    [SerializeField] private int BonusArmor = 2;
    [Tooltip("For how long of the Guardian Field's cooldown is Guardian Field Active. Cooldown starts once the duration is passed.")]
    [SerializeField][Range(0.25f, 0.75f)] private float GFPercentage = 0.5f;
    private float GuardianFieldDuration = 5f;

    [Header("Elven Settings")]
    [Tooltip("A higher number means faster projectiles.")]
    [SerializeField] private float BonusProjectileSpeed;
    [Tooltip("A higher number means faster movement.")]
    [SerializeField][Range(1.01f, 2.5f)] private float BonusMoveSpeed;

    protected void Awake()
    {
        startPos = transform.position;
        endPos = transform.position;

        AttackReady = true;

        StartCoroutine(PlayerMovement());

        if (_characterClass == CharacterClass.Valkyrie)
        {
            //Adding bonus armor to character's armor level.
            Armor += BonusArmor;

            //Calculating the persentage of cooldown time Guardian Field is active.
            GuardianFieldDuration = SkillDelay * GFPercentage;
        }

        if (_characterClass == CharacterClass.ElvenOne)
        {
            ProjectileSpeed += BonusProjectileSpeed;
            MoveTime /= BonusMoveSpeed;
        }
    }

    public void TakeDamage(int damageTaken)
    {
        if (vulnerable)
        {
            damageTaken -= Armor;
            if (damageTaken > 0)
                Health -= damageTaken;
        }
    }

    public void Attack()
    {
        //Returning if action is not performed or attack is not ready.
        if (!AttackReady) return;

        GameObject projectile = Instantiate(AttackPrefab, transform.position, transform.rotation);
        projectile.GetComponent<Rigidbody>().velocity = (transform.forward * ProjectileSpeed);

        projectile.GetComponent<PlayerProjectile>().DamageDropOff = DamageDropOff;
        projectile.GetComponent<PlayerProjectile>().DamageDropOffAmount = DamageDropOffAmount;
        projectile.GetComponent<PlayerProjectile>().LifeSpan = ProjectileLifeSpan;
        
        AttackReady = false;
        StartCoroutine("AttackCooldown");
    }

    public void UsePotion()
    {
        //Ensuring the action only happens once and that the player has a Potion to use.
        if (MagicPotions <= 0) return;

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
    public void Move(Vector2 input)
    {
        //Returning if no input.
        if (input == Vector2.zero)
            currentDirection = Direction.none;

        //Determining which direction the player wants to go.
        else if (input.y >= _sensitivity)
        {
            if (input.x >= _sensitivity)
                currentDirection = Direction.upRight;
            else if (input.x <= -_sensitivity)
                currentDirection = Direction.upLeft;

            else
                currentDirection = Direction.up;
        }
        else if (input.y <= -_sensitivity)
        {
            if (input.x >= _sensitivity)
                currentDirection = Direction.downRight;
            else if (input.x <= -_sensitivity)
                currentDirection = Direction.downLeft;

            else
                currentDirection = Direction.down;
        }
        else if (input.x >= _sensitivity)
            currentDirection = Direction.right;
        else if (input.x <= -_sensitivity)
            currentDirection = Direction.left;
    }

    protected void OnCollisionEnter(Collision collision)
    {
        //Opening Door on Collision.
        if (collision.gameObject.CompareTag("Door") && UseKey())
        {
            Destroy(collision.gameObject);
        }
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
        if (Physics.Raycast(LookingDirection, out hit, 1.1f, _wallLayer))
        {
            return false;
        }

        else
            return true;
    }

    /// Skills \\\
    //General Skill Call
    public void UseSkill()
    {
        switch (_characterClass)
        {
            case CharacterClass.Warrior:
                Cleave();
                break;
            case CharacterClass.Wizard:
                ElementalShift();
                break;
            case CharacterClass.Valkyrie:
                if (SkillReady)
                    StartCoroutine(GuardianField());
                break;
            case CharacterClass.ElvenOne:
                TrueSight();
                break;

            default:
                Debug.LogError("Unexpected enum for _characterClass in Adventurer on: " + gameObject.name + ".");
                break;
        }
    }

    //Warrior Skill
    protected void Cleave()
    {
        if (SkillReady)
        {
            for (int index = 0; index < 3; index++)
            {
                GameObject projectile = Instantiate(AttackPrefab, transform.position, transform.rotation);
                switch (index)
                {
                    case 0:
                        projectile.GetComponent<Rigidbody>().velocity = (transform.forward * ProjectileSpeed);
                        break;
                    case 1:
                        projectile.GetComponent<Rigidbody>().velocity = ((transform.forward - transform.right) * ProjectileSpeed);
                        break;
                    case 2:
                        projectile.GetComponent<Rigidbody>().velocity = ((transform.forward + transform.right) * ProjectileSpeed);
                        break;
                    default:
                        break;
                }

                projectile.GetComponent<PlayerProjectile>().DamageDropOff = DamageDropOff;
                projectile.GetComponent<PlayerProjectile>().DamageDropOffAmount = DamageDropOffAmount;
                projectile.GetComponent<PlayerProjectile>().LifeSpan = ProjectileLifeSpan;
            }

            StartCoroutine("SkillCooldown");
        }
    }

    //Wizard Skill
    protected void ElementalShift()
    {
        ///Switching Element.\\\
        int temp = (int)AttackElement;
        temp++;
        temp = temp % 7;

        if (temp == 0)
            temp++;

        AttackElement = (Element)temp;

        ///Exploding Wizard\\\
        if (SkillReady)
        {
            float tempSpeed = ProjectileSpeed / 2;
            for (int index = 0; index < 8; index++)
            {
                GameObject projectile = Instantiate(AttackPrefab, transform.position, transform.rotation);
                switch (index)
                {
                    case 0:
                        projectile.GetComponent<Rigidbody>().velocity = (transform.forward * tempSpeed);
                        break;
                    case 1:
                        projectile.GetComponent<Rigidbody>().velocity = ((transform.forward - transform.right) * tempSpeed);
                        break;
                    case 2:
                        projectile.GetComponent<Rigidbody>().velocity = ((transform.forward + transform.right) * tempSpeed);
                        break;
                    case 3:
                        projectile.GetComponent<Rigidbody>().velocity = ((transform.right) * tempSpeed);
                        break;
                    case 4:
                        projectile.GetComponent<Rigidbody>().velocity = ((-transform.right) * tempSpeed);
                        break;
                    case 5:
                        projectile.GetComponent<Rigidbody>().velocity = ((-transform.forward + transform.right) * tempSpeed);
                        break;
                    case 6:
                        projectile.GetComponent<Rigidbody>().velocity = ((-transform.forward - transform.right) * tempSpeed);
                        break;
                    case 7:
                        projectile.GetComponent<Rigidbody>().velocity = ((-transform.forward) * tempSpeed);
                        break;
                    default:
                        break;
                }

                projectile.GetComponent<PlayerProjectile>().LifeSpan = 0.4f;
            }

            StartCoroutine("SkillCooldown");
        }
    }

    //ElvenOne Skill
    protected void TrueSight()
    {
        if (SkillReady)
        {


            StartCoroutine("SkillCooldown");
        }
    }


    /// IEnumerators \\\

    //This handles the actual movement of the player character.
    protected IEnumerator PlayerMovement()
    {
        while (true)
        {
            _moveTimePassed = 0f;
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

            transform.LookAt(endPos);


            //Verifying the player can move in this direction.
            if (CheckWalls())
            {
                GameObject temp = GameObject.CreatePrimitive(PrimitiveType.Cube);
                temp.transform.position = endPos;
                temp.layer = LayerMask.NameToLayer("PlayerSpecificWall");
                temp.GetComponent<MeshFilter>().mesh = null;
                Destroy(temp, MoveTime);

                while (_moveTimePassed < MoveTime)
                {
                    yield return new WaitForFixedUpdate();

                    _moveTimePassed += Time.fixedDeltaTime;
                    transform.position = Vector3.Lerp(startPos, endPos, _moveTimePassed / MoveTime);
                }
            }

            else
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
        //Disabling ability to use skill.
        SkillReady = false;
        //Setting skill cooldown timer.
        _skillTimePassed = SkillDelay;

        while (_skillTimePassed > 0)
        {
            Debug.Log("Time Remaining: " + _skillTimePassed);
            _skillTimePassed--;
            yield return new WaitForSeconds(1f);
        }

        SkillReady = true;
        StopCoroutine("SkillCooldown");
    }

    //Valkyrie Skill Effect
    protected IEnumerator GuardianField()
    {
        vulnerable = false;

        yield return new WaitForSeconds(GuardianFieldDuration);
        StartCoroutine("SkillCooldown");

        vulnerable = true;
    }
}
