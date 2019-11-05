using UnityEngine;

public class EnemyAttributes : MonoBehaviour
{

    #region public Methods

    public void takeDamage(int damageToDeal)
    {
        // TODO: Take damage
        Debug.Log(this.name + ": Taking " + damageToDeal.ToString() + " Damage");
    }

    #endregion
}
