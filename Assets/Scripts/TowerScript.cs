using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    // Tower targeting variables
    private Transform target; // Target that tower will lock onto
    public float range = 20f; // tower range
    public Transform partToRotate; // Part of the tower that is going to rotate, not the base
    public float turnSpeed = 10f;

    // Tower shoot variables
    public float fireRate = 1f;
    private float fireCountdown = 0f; // This is when the tower is able to shoot again
    public GameObject bulletPrefab;
    public Transform firePoint; // Reference empty game object so the bullet can shoot from the barrel

    private EnemyScript targetEnemy;
    public float slowAmount = 0.5f;
    public bool isSlowTurret;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f); // Repeat this function twice a second
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenuScript.isPaused)
        {
            // If there is no target, do nothing
            if (target == null)
            {
                return;
            }

            Vector3 direction = target.position - transform.position; // Find direction from tower position to target position
            Quaternion lookRotation = Quaternion.LookRotation(direction); // Which way the tower will be looking according to the direction
            Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles; // Convert rotation to Euler Angles; Lerp function smooths the rotation movement
            partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f); // Only rotate the head around y-axis

            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }

            fireCountdown -= Time.deltaTime; // Every second, the countdown is reduced by 1
        }
    }

    // Find closest target within range
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy"); // Array of all enemies
        float shortestDistance = Mathf.Infinity; // Stores shortest distance from tower to enemy thus far; infinity is for when enemy hasn't been found yet
        GameObject nearestEnemy = null;

        // Looping through all enemies
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position); // Return distance from tower to enemy 

            if (distanceToEnemy < shortestDistance) // Checking if current distance is less than the shortest distance found
            {
                shortestDistance = distanceToEnemy; // If less than, set equal. Now we have a new shortest distance
                nearestEnemy = enemy; // Also update the nearest enemy to be the current enemy being iterated over
            }
        }

        // If enemy is found and within turret range
        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform; // Closest target lock on
            targetEnemy = nearestEnemy.GetComponent<EnemyScript>();
        }
        else
        {
            target = null; // No target lock on
        }
    }

    void Shoot()
    {
        if (!isSlowTurret)
        {
            GameObject damageBulletGameObject = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            DamageBulletScript damageBullet = damageBulletGameObject.GetComponent<DamageBulletScript>();

            if (damageBullet != null)
            {
                damageBullet.Seek(target);
            }
        }
        else if (isSlowTurret)
        {
            GameObject slowBulletGameObject = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            SlowBulletScript slowBullet = slowBulletGameObject.GetComponent<SlowBulletScript>();

            targetEnemy.Slow(slowAmount);

            if (slowBullet != null)
            {
                slowBullet.Seek(target);
            }
        }
    }

    void OnDrawGizmosSelected() //del later
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);

    }

}

