using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    WaveConfig waveConfig;
    List<Transform> waypoints;
    int waypointIndex = 0;
    private int damage;
    private int enemyHealth;
    private int coins;
    private int randomCoins;

    void Start()
    {
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[waypointIndex].transform.position;
        damage = waveConfig.GetDamage();
        enemyHealth = waveConfig.GetHealth();
        coins = waveConfig.GetCoins();
        randomCoins = waveConfig.GetRandomCoins();
    }

    void Update() 
    {
        Move();
    }

    public void SetWaveConfig(WaveConfig waveConfig)
    {
        this.waveConfig = waveConfig;
    }

    public void TakeDamage (int amount)
    {
        enemyHealth -= amount;

        if(enemyHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        PlayerStats.Money += coins+ Random.Range(-5, randomCoins);
        Destroy(gameObject);
    }

    private void Move()
    {
        if (waypointIndex <= waypoints.Count -1)
        {
            var targetPosition = waypoints[waypointIndex].transform.position;
            var movementThisFrame = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector3.MoveTowards
                (transform.position, targetPosition, movementThisFrame);

            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            PlayerStats.Lives -= damage;
            Destroy(gameObject);
        }
    }
}
