using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] TurredConfig turredConfig;
    private Transform target;
    public float speed = 70f;
    public GameObject ImpactFlame;
    private int damage;

    private void Start()
    {
        damage = turredConfig.GetTurredDamage();
    }
    public void Seek (Transform _target)
    {
        target = _target;
    }
    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void Damage(Transform enemy)
    {
        EnemyPathing e = enemy.GetComponent<EnemyPathing>();

        if (e != null)
        {
            e.TakeDamage(damage);
        }
        
    }
    void HitTarget()
    {
        GameObject effectIns = Instantiate(ImpactFlame, transform.position, transform.rotation);
        Destroy(effectIns, 2f);

        Damage(target);
        Destroy(gameObject);

    }
}

