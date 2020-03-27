using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More one build in scene");
        }
        instance = this;
    }

    public GameObject standartTurredPrefab;

    public GameObject rocketTurredPrefab;
    /*private void Start()
    {
        turretToBuild = standartTurredPrefab;
    }*/

    private GameObject turretToBuild;

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }
    
    public void SetTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
    }
}
