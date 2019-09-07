using System.Collections;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    //Singleton
    public static BuildManager instance;

    public GameObject buildEffect;

    GameObject turretToBuild;

    private void Awake()
    {
        if(instance != null)
        {
            return;
        }
        instance = this;
    }

    private void Start()
    {
        //turretToBuild = standardTurretPrefab;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            turretToBuild = null;
            //Shop.shop.setSelectedItem(null);
        }

        if(PlayerStatus.gameIsOver)
        {
            turretToBuild = null;
        }
    }

    public void setTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
    }

    public GameObject getTurretToBuild()
    {
        return turretToBuild;
    }

    public void showBuildEffect(Vector3 buildPosition)
    {
        Instantiate(buildEffect, buildPosition, Quaternion.identity);
    }
}
