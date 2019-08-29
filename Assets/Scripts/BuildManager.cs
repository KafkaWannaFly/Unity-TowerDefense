using System.Collections;
using System.Collections.Generic;
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
        turretToBuild = standardTurretPrefab;
    }

    public GameObject getTurretToBuild()
    {
        return turretToBuild;
    }
}
