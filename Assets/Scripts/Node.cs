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
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (currentTurret != null)  //Already built something on
        {
            rend.material.color = Color.red;
            return;
        }

        if (BuildManager.instance.getTurretToBuild() != null)   //Not enough money?
        {
            if(BuildManager.instance.getTurretToBuild().GetComponent<MyTurret>().cost > 
                                                                                PlayerStatus.instance.getCurrentMoney())
            {
                rend.material.color = Color.red;
                return;
            }
        }
        else    //Currently not seclecting anything
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
        //if(currentTurret == null)
        //{
        //    return;
        //}

        if(BuildManager.instance.getTurretToBuild() == null)
        {
            return;
        }
        MyTurret myTurret = BuildManager.instance.getTurretToBuild().GetComponent<MyTurret>();

        if(PlayerStatus.instance.canWeBuyThisTurret(myTurret) == false)
        {
            return;
        }

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
            return;
        }

        turret = Instantiate(turret, this.transform.position + offsetTurretPosition, this.transform.rotation);

        BuildManager.instance.showBuildEffect(this.transform.position + offsetTurretPosition);

        PlayerStatus.instance.buyTurret(turret.GetComponent<MyTurret>());
    }
}
