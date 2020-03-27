using System.Collections;
using UnityEngine;
using System.Collections.Generic;


public class Node : MonoBehaviour
{
    [SerializeField] GameObject missleTurred_prefab;
    [SerializeField] GameObject laserTurred_Prefab;
    [SerializeField] GameObject gunTurred_Prefab;
    [SerializeField] GameObject superTurred_Prefab;
    [SerializeField] GameObject destroy_Turred_meny;
    [SerializeField] TurredConfig misleTurredConfig;
    [SerializeField] TurredConfig laserTurredConfig;
    [SerializeField] TurredConfig superTurredConfig;
    [SerializeField] TurredConfig gunTurredConfig;
    
    public Color hoverColor;
    private GameObject turret;
    private Renderer rend;
    private Color startColor;
    public Vector3 positionOffset;

    private int missleTurred_cost;
    private int superTurred_cost;
    private int laserTurred_cost;
    private int gunTurred_cost;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        missleTurred_cost = misleTurredConfig.GetTurredCost();
        superTurred_cost = superTurredConfig.GetTurredCost();
        laserTurred_cost = laserTurredConfig.GetTurredCost();
        gunTurred_cost = gunTurredConfig.GetTurredCost();
    }
    private void Update()
    {
        
    }

    void Exit()
    {
        rend.material.color = startColor;
    }

    public void ButEnter()
    {
       

        

        
    }

    private IEnumerator ButEX()
    {
        yield return new WaitForSeconds(3f);
        Exit();
    }
    public void BuildLaserTurred()
    {
        if (turret != null)
        {
            
            Debug.Log("Cant Build Here");
            destroy_Turred_meny.SetActive(true);
            return;
        }
      
        if(PlayerStats.Money > laserTurred_cost)
        {
            PlayerStats.Money -= laserTurred_cost;
            GameObject turretToBuild = laserTurred_Prefab;
            turret = Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
            rend.material.color = hoverColor;
            StartCoroutine(ButEX());
        }
        
        else
        {
            return;
        }
        
    }

    public void MissleTurredBuild()
    {
        if (turret != null)
        {
            Debug.Log("Cant Build Here");
           
            return;
        }
       
        if (PlayerStats.Money > missleTurred_cost)
        {
            PlayerStats.Money -= missleTurred_cost;
            GameObject turretToBuild = missleTurred_prefab;
            turret = Instantiate(turretToBuild, transform.position, transform.rotation);
            rend.material.color = hoverColor;
            StartCoroutine(ButEX());
        }
        else
        {
            return;
        }
       
    }

    public void GunTurredBuild()
    {
        if (turret != null)
        {
            Debug.Log("Cant Build Here");
           
            return;
        }
       
        if (PlayerStats.Money > gunTurred_cost)
        {
            PlayerStats.Money -= gunTurred_cost;
            GameObject turretToBuild = gunTurred_Prefab;
            turret = Instantiate(turretToBuild, transform.position, transform.rotation);
            rend.material.color = hoverColor;
            StartCoroutine(ButEX());
        }
        else
        {
            return;
        }
        
    }

    public void SuperTurredBuild()
    {
        if (turret != null)
        {
            Debug.Log("Cant Build Here");
           
            return;
        }
        
        if (PlayerStats.Money > superTurred_cost)
        {
            PlayerStats.Money -= superTurred_cost;
            GameObject turretToBuild = superTurred_Prefab;
            turret = Instantiate(turretToBuild, transform.position, transform.rotation);
            rend.material.color = hoverColor;
            StartCoroutine(ButEX());
        }
        else
        {
            return;
        }
    }

    public void DestroyToured()
    {
      

        if (turret != null)
        {
            PlayerStats.Money += 30;
            Debug.Log("123");
            Destroy(turret);
        }
    }
}
