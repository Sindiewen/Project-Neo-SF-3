using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    #region Variables

    // Public Variables
    // ------------------------------------
    [Header("Combat Circle")]
    public Circle attackCircle;         // Circle for how calculating the attack range
                                        // Radius = attack range, Positon = circle + obj positon
    public LayerMask collisionMask;

    // private variables
    // component references
    private EnemyAttributes enemyAttributes;

    // timers
    private float attackTimer = 0;
    private bool timerStart = false;
    private bool canAttack = false;


    #endregion

    /// <summary>
    /// Unity start method
    /// 
    /// runs at initialization
    /// </summary>
    private void Start()
    {
        enemyAttributes = GetComponent<EnemyAttributes>();
    }

    /// <summary>
    /// Unity update method
    /// 
    /// runs once per framce
    /// </summary>
    private void Update()
    {
        // initiates attack
        initiateAttack();
    }



    // Combat Methods
    // --------------------------------------------

    /// <summary>
    /// Sets timer to max value
    /// </summary>
    private void setTimer()
    {
        attackTimer = enemyAttributes.atkSpeed;
        canAttack = false;
        timerStart = true;
    }

    /// <summary>
    /// Decrements timer
    /// </summary>
    private void resetTimer()
    {
        attackTimer -= Time.deltaTime;
        Debug.Log("Attack in " + (int)attackTimer);

        // If timer runs out, the enemy can attack
        if (attackTimer <= 0)
        {
            canAttack = true;
            timerStart = false;
        }
    }

    /// <summary>
    /// manually restarts timer;
    /// </summary>
    private void restartTimer()
    {
        attackTimer = 0;
        canAttack = false;
        timerStart = false;
    }

    /// <summary>
    /// Initiates attack
    /// </summary>
    private void initiateAttack()
    {
        // Creates circleCast at player
        Vector2 rayOrigin = (Vector2)transform.position + attackCircle.Position;
        RaycastHit2D[] hit = Physics2D.CircleCastAll(rayOrigin, attackCircle.Radius, Vector3.zero, 0, collisionMask);

        // if players found
        if (hit.Length > 0)
        {
            Debug.Log("Player found");
            // if timer not started, start timer
            if (!timerStart && !canAttack)
            {
                Debug.Log("Start delay attack timer");
                // sets atack delay timer
                setTimer();
            }
            // decrement timer
            else if (timerStart && !canAttack)
            {
                Debug.Log("Decrement delay attack timer");
                resetTimer();
            }
            // if can attack
            else if(!timerStart && canAttack)
            {
                Debug.Log("Attacking player");
                for (int i = 0; i < hit.Length; i++)
                {
                    restartTimer();
                    hit[i].transform.GetComponent<PlayerAttributesController>().takeDamage(enemyAttributes.atkStrength);
                }
            }
        }
    }


}
