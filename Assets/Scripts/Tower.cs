using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField]TurredConfig turredConfig;
    Transform target;

    [Header ("Atributes")]
    private float range = 1f;
    private float turnSpeed = 10f;
    private float fireRate = 1f;
    private float fireCountdown = 0f;
    [Header ("Unity Setup Fields")]
    private string enemyTag = "Enemy";

    private GameObject bulletPrefab;
    public Transform[] firePoint;

    public Transform partToRotate;
    // Start is called before the first frame update
    void Start()
    {
        enemyTag = turredConfig.GetEnemyTag();
        turnSpeed = turredConfig.GetTurnSpeed();
        bulletPrefab = turredConfig.GetTurredBullet();
        fireRate = turredConfig.GetAttackSpeed();
        range = turredConfig.GetTurredRange();
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;
        }

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }
        fireCountdown -= Time.deltaTime;
    }

    void Shoot()
    {
        foreach (Transform sp in firePoint)
        {
            GameObject bulletGO = Instantiate(bulletPrefab, sp.position, sp.rotation);
            Bullet bullet = bulletGO.GetComponent<Bullet>();
            if (bullet != null)
            {
                bullet.Seek(target);
            }
        }
       
       

        
    }

    void UpdateTarget()
    {

        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shotesDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shotesDistance)
            {
                shotesDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shotesDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    
}
