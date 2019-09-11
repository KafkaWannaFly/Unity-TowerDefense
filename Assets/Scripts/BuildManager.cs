using System.Collections;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    //Singleton
    public static BuildManager instance;

    public GameObject buildEffect;
    public GameObject sellEffect;
    public NodeUI nodeUI;

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
        return this.turretToBuild;
    }

    public void showBuildEffect(Vector3 effectPosition)
    {
        Instantiate(buildEffect, effectPosition, Quaternion.identity);
    }

    public void showSellEffect(Vector3 effectPosition)
    {
        Instantiate(sellEffect, effectPosition, Quaternion.identity);
    }
}
