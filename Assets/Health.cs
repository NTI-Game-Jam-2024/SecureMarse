using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private int hitPoints = 2;

    public void TakeDamage(float amount)
    {
         if (hitPoints <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        EnemySpawner.onEnemyDestroy.Invoke();
        Destroy(gameObject);
    }
}