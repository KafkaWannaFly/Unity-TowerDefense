using UnityEngine;

public class Shop : MonoBehaviour
{
    GameObject selectedItem;
    GameObject cursor;

    public void setSelectedItem(GameObject item)
    {
        selectedItem = item;

        BuildManager.instance.setTurretToBuild(selectedItem);
    }

    public GameObject getSelectedItem()
    {
        return selectedItem;
    }
}
