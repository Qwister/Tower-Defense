using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Turred Config")]
public class TurredConfig : ScriptableObject
{
    [SerializeField] GameObject turredPrefab;
    [SerializeField] GameObject turredBullet;
    [SerializeField] int turredCost;
    [SerializeField] int turredDamage;
    [SerializeField] float attackSpeed;
    [SerializeField] float turredRange;
    [SerializeField] float turnSpeed;
    [SerializeField] string enemyTag;

    public float GetAttackSpeed() { return attackSpeed; }
    public int GetTurredDamage() { return turredDamage; }
    public int GetTurredCost() { return turredCost; }
    public float GetTurredRange() { return turredRange; }
    public float GetTurnSpeed() { return turnSpeed; }
    public GameObject GetTurredBullet() { return turredBullet; }
    public string GetEnemyTag() { return enemyTag; }
}
