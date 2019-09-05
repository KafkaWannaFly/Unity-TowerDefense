using UnityEngine.UI;
using UnityEngine;

public class PriceTag : MonoBehaviour
{
    public GameObject turretPrefab;
    private void Start()
    {
        MyTurret myTurret = turretPrefab.GetComponent<MyTurret>();

        Text myText = this.gameObject.GetComponent<Text>();
        myText.text = "$" + myTurret.cost.ToString();
    }
}
