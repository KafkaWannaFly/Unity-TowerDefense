using UnityEngine;

public class Shop : MonoBehaviour
{
    GameObject selectedItem;
    GameObject cursor;

    public void setSelectedItem(GameObject item)
    {
        selectedItem = item;

        BuildManager buildManager = BuildManager.instance;
        buildManager.setTurretToBuild(selectedItem);

        Debug.Log("Shop.cs: setSelectedItem()");
    }

    public GameObject getSelectedItem()
    {
        return selectedItem;
    }

}
