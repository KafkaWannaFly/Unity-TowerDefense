using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    public GameObject mainUI;
    public Button upgradeButton;
    public Text upgradeCost;
    public Text sellAmount;

    Node target;

    private void Start()
    {
        mainUI.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            this.hideNodeUI();
        }

        this.setUpgradeCostText();

        this.setSellAmountText();
    }

    void setUpgradeCostText()
    {
        if (target != null)
        {
            GameObject currentTurret = target.getCurrentTurret();
            if (currentTurret.GetComponent<MyTurret>().upgradedVersion == null)
            {
                upgradeButton.interactable = false;
                upgradeCost.text = "NONE";
            }
            else
            {
                upgradeButton.interactable = true;
                upgradeCost.text = currentTurret.GetComponent<MyTurret>().upgradedVersion.GetComponent<MyTurret>().cost.ToString();
            }
        }
    }

    void setSellAmountText()
    {
        if (this.target == null)
            return;

        this.sellAmount.text = this.target.getCurrentTurret().GetComponent<MyTurret>().getSellPrice().ToString();
    }

    public void setNodeUI(Node _target)
    {
        this.target = _target;
        this.transform.position = this.target.transform.position;
        mainUI.SetActive(true);
    }

    public Node targetNode
    {
        get { return this.target; }
    }

    public Node getTargetNode()
    {
        return this.target;
    }

    public void hideNodeUI()
    {
        mainUI.SetActive(false);
        this.target = null;
    }

    public void upgradeTurret()
    {
        this.target.upgradeTurret();
    }

    public void sellTurret()
    {
        this.target.sellTurret();
        this.hideNodeUI();
    }

}
