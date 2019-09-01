using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color defaultColor;
    public Color onMouseColor;
    public Vector3 offsetTurretPosition;

    GameObject currentTurret;

    private Renderer rend;

    private void Awake()
    {
        rend = GetComponent<Renderer>();
    }

    private void OnMouseEnter()
    {
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        rend.material.color = onMouseColor;
    }

    private void OnMouseExit()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        rend.material.color = defaultColor;
    }

    private void OnMouseDown()
    {
        buildTurret();
    }

    void buildTurret()
    {
        //Already had a turret on it
        if(currentTurret != null)
        {
            Debug.Log("Can't build turret. TODO: Make UI");
            return;
        }
        
        //GameObject turretToBuild = BuildManager.instance.getTurretToBuild();
        GameObject turret = BuildManager.instance.getTurretToBuild();
        currentTurret = turret;
        if(turret == null)
        {
            Debug.Log("From Node.cs: turretToBuild is a null");
            return;
        }
        turret = Instantiate(turret, this.transform.position + offsetTurretPosition, this.transform.rotation);
    }
}
