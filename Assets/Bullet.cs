using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb; // Make sure to attach the Rigidbody2D component in the Inspector

    [Header("Attributes")]
    [SerializeField] private int bulletDamage = 1;
    [SerializeField] private float bulletSpeed = 5f; // You can adjust the bullet speed in the Inspector

    private Transform target;

    public void SetTarget(Transform _target)
    {
        target = _target;
    }

    private void FixedUpdate()
    {
        if (!target) return;

        Vector2 direction = (target.position - transform.position).normalized;
        rb.velocity = direction * bulletSpeed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
    Health enemyHealth = other.gameObject.GetComponent<Health>();
    if (enemyHealth != null)
    {
        enemyHealth.TakeDamage(bulletDamage);
        Destroy(gameObject); 
    }
    if (other.gameObject.CompareTag("Enemy")) 
{
    other.gameObject.GetComponent<Health>().TakeDamage(bulletDamage);
    Destroy(gameObject);
}
    }
}