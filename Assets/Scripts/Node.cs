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
        if (currentTurret != null)
        {
            BuildManager.instance.nodeUI.setNodeUI(this);
        }

        if (BuildManager.instance.getTurretToBuild() == null)
        {
            return;
        }

        MyTurret myTurret = BuildManager.instance.getTurretToBuild().GetComponent<MyTurret>();

        if(PlayerStatus.instance.canWeBuyThisTurret(myTurret) == false)
        {
            return;
        }

        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        buildTurret();
    }

    public GameObject getCurrentTurret()
    {
        return this.currentTurret;
    }

    void buildTurret()
    {        
        if(currentTurret != null)
        {
            return;
        }
        //GameObject turretToBuild = BuildManager.instance.getTurretToBuild();
        GameObject turret = BuildManager.instance.getTurretToBuild();
        if(turret == null)
        {
            return;
        }

        this.currentTurret = Instantiate(turret, this.transform.position + offsetTurretPosition, this.transform.rotation);

        BuildManager.instance.showBuildEffect(this.transform.position + offsetTurretPosition);

        PlayerStatus.instance.buyTurret(turret.GetComponent<MyTurret>());
    }

    public void upgradeTurret()
    {
        MyTurret myTurret = currentTurret.GetComponent<MyTurret>();

        if(myTurret.isUpgrade)
        {
            return;
        }
        else
        {
            if (myTurret.upgradedVersion == null)
                return;
            MyTurret upgradedTurret = myTurret.upgradedVersion.GetComponent<MyTurret>();

            if(PlayerStatus.instance.canWeBuyThisTurret(upgradedTurret))
            {
                PlayerStatus.instance.buyTurret(upgradedTurret);

                Destroy(this.currentTurret);

                this.currentTurret = Instantiate(myTurret.upgradedVersion, this.transform.position + offsetTurretPosition, this.transform.rotation);

                BuildManager.instance.showBuildEffect(this.transform.position + offsetTurretPosition);
            }
        }
    }

    public void sellTurret()
    {
        if (currentTurret == null)
            return;

        PlayerStatus.instance.increaseMoney(currentTurret.GetComponent<MyTurret>().getSellPrice());

        Destroy(this.currentTurret);

        BuildManager.instance.showSellEffect(this.transform.position + offsetTurretPosition);
    }
}
