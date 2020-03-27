using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void PurchaseStandartTurret()
    {
        Debug.Log("Standart Turred Purchased");
        buildManager.SetTurretToBuild(buildManager.standartTurredPrefab);
    }

    public void PurchaseRocketTurret()
    {
        Debug.Log("Standart Turred Purchased");
        buildManager.SetTurretToBuild(buildManager.rocketTurredPrefab);
    }
}
