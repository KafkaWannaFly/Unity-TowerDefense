using System.Collections;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    //Singleton
    public static BuildManager instance;
    private void Awake()
    {
        if(instance != null)
        {
            return;
        }
        instance = this;
    }

    public GameObject standardTurretPrefab;

    GameObject turretToBuild;

    private void Start()
    {
        //turretToBuild = standardTurretPrefab;
    }

    public void setTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;

        Debug.Log("BuildManager.cs: setTurretToBuild");
    }

    public GameObject getTurretToBuild()
    {
        return turretToBuild;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            Debug.Log("BuildManager: set turretToBuild = null");
            turretToBuild = null;
        }
    }
}
