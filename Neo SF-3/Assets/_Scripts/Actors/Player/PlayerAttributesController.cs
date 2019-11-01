using UnityEngine;

public class PlayerAttributesController : MonoBehaviour
{

    // Variables
    #region Variables
    // Public Variables
    // --------------------------------
    [Header("Player Attributes")]
    public int playerHealth;            // Current player health
    public int playerHealthMax;         // Max player health

    [Header("Player Combat Values")]
    public int AttackStrength;          // Player attack strength
    public float comboResetCooldown;    // How long it takes before the attack's can be used again outside of combo
    public float midComboAtkCooldown;   // How long it takes before the next attack in the combo chain can be initiated


    // Private Variables
    // ---------------------------------
    // Component references

    #endregion

}
