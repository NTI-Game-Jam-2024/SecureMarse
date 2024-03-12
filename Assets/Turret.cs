using UnityEngine;

public class Turret : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private LayerMask enemyMask; // Ensure this shows in Inspector
    [SerializeField] private GameObject bulletPrefab; // Drag your bullet prefab here
    [SerializeField] private Transform firingPoint; // Assign the firing point Transform

    [Header("Attributes")]
    [SerializeField] private float targetingRange = 5f; // Visible in Inspector
    [SerializeField] private float bps = 1f; // Bullets per second, also visible

    private Transform target;
    private float timeUntilFire;

    private void Update()
    {
        if (target == null || !CheckTargetIsInRange())
        {
            FindTarget();
            return;
        }

        timeUntilFire += Time.deltaTime;
        if (timeUntilFire >= 1f / bps)
        {
            Shoot();
            timeUntilFire = 0f;
        }
    }

    private void Shoot()
    {
        GameObject bulletObj = Instantiate(bulletPrefab, firingPoint.position, Quaternion.identity);
        Bullet bulletScript = bulletObj.GetComponent<Bullet>(); // Ensure your bullet prefab has a Bullet component
        if (bulletScript != null)
        {
            bulletScript.SetTarget(target); // This assumes your Bullet script has a method named SetTarget accepting a Transform
        }
    }

    private void FindTarget()
    {
        // CircleCast to find the enemy within range
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, targetingRange, Vector2.zero, 0f, enemyMask);
        if (hit.collider != null)
        {
            target = hit.transform;
        }
        else
        {
            target = null;
        }
    }

    private bool CheckTargetIsInRange()
    {
        if (target == null) return false;
        return Vector2.Distance(transform.position, target.position) <= targetingRange;
    }
}