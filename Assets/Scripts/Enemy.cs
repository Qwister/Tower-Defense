using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    EnemyConfig enemyConfig;
    private int enemyHealth;
    private int enemyDamage;
    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = enemyConfig.GetEnemyHealth();
        enemyDamage = enemyConfig.GetEnemyDamage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
