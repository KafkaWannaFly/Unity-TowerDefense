using UnityEngine;

public class Shop : MonoBehaviour
{
    //Singleton
    static Shop shop;
    private void Awake()
    {
        if (shop == null)
        {
            shop = this;
        }
    }

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
