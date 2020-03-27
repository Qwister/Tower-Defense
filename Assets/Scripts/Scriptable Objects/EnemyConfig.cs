using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Enemy Config")]
public class EnemyConfig : ScriptableObject
{
    [SerializeField] int enemyHealth;
    [SerializeField] int enemyDamage;
    
    public int GetEnemyHealth() { return enemyHealth; }
    public int GetEnemyDamage() { return enemyDamage; }
}
