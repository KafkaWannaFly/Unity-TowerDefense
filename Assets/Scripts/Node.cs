using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color defaultColor;
    public Color onMouseColor;
    public Vector3 offsetTurretPosition;
    GameObject turret;

    private Renderer rend;

    private void Awake()
    {
        rend = GetComponent<Renderer>();
    }

    private void OnMouseEnter()
    {
        rend.material.color = onMouseColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = defaultColor;
    }

    private void OnMouseDown()
    {
        buildTurret();
    }

    void buildTurret()
    {
        if(turret != null)
        {
            Debug.Log("Can't build turret. TODO: Make UI");
            return;
        }

        //GameObject turretToBuild = BuildManager.instance.getTurretToBuild();
        turret = BuildManager.instance.getTurretToBuild();
        turret = Instantiate(turret, this.transform.position + offsetTurretPosition, this.transform.rotation);
    }
}
