using UnityEngine;

[System.Serializable]
public class itemDrops
{
    public itemDrop itemDrop;
    public float itemDropRate;
}

public class EnemyAttributes : MonoBehaviour
{

    // Variables
    // ------------------------------
    #region Variables

    // Public Variables
    public int curHealth;           // The current enemy health
    public int maxHealth;           // The max enemy health
    public int atkStrength;         // How strong the enemy is 
    public float atkSpeed;          // How fast the enemy can attack per second
    public int physDefense;         // How much damage the enemy will resist
    public float enemyMoveSpeed;

    [Header("Sounds")]
    public AudioClip attack;
    public AudioClip takingDamage;
    public AudioClip death;

    [Header("Item Drops")]
    public itemDrops[] itemDrops;

    [HideInInspector] public AudioSource audioSource;

    #endregion

    // Private methods
    // ------------------------------
    #region private methods

    /// <summary>
    /// Unity start method
    /// 
    /// RUns at initialization
    /// </summary>
    private void Start()
    {
        // Sets health value
        curHealth = maxHealth;

        // component
        audioSource = GetComponent<AudioSource>();
    }

    #endregion

    #region public Methods

    public void takeDamage(int damageToDeal)
    {

        // Calculate how much damage the enemy will take
        // If damage to deal is greater than the defense, then subtact def
        // from the damage to deal and apply that to the curHealth.
        if (damageToDeal >= physDefense)
        {
            Debug.Log(this.name + " is taking " + (damageToDeal - physDefense).ToString() + " damage");
            curHealth -= (damageToDeal - physDefense);
        }
        // Otherwise, enemy will take scratch damage
        // Or just 1 damage
        else
        {
            Debug.Log(this.name + " is taking 1 damage");
            curHealth -= 1;
        }

        // Check for enemy knockout
        if (curHealth <= 0)
        {
            // randomly drop item
            itemDrops newItem = null;
            newItem = itemDrops[Random.Range(0, itemDrops.Length)];
            if (newItem != null && Random.Range(0, 100) < newItem.itemDropRate)
            {
                // Drop item
                // Instantiate item at this enemy's feet
                Instantiate(newItem.itemDrop.gameObject, transform.position, Quaternion.identity);
            }
            audioSource.PlayOneShot(death);

            // Destroy this object
            Destroy(this.gameObject);
        }
        else
        {
            audioSource.PlayOneShot(takingDamage);
        }

    }

    #endregion
}
