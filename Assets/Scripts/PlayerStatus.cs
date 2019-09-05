using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    static public PlayerStatus instance;

    public int startMoney = 250;
    public int HP;

    public Text textMoney;
    public Text textHP;

    int currentMoney;

    private void Awake()
    {
        if (instance != null)
            return;
        instance = this;
    }

    private void Start()
    {
        currentMoney = startMoney;
    }

    private void Update()
    {
        if(this.HP <= 0)
        {
            endGame();
            return;
        }

        showCurrentMoney();
        showCurrentHP();
    }

    public bool canWeBuyThisTurret(MyTurret turret)
    {
        if (turret == null)
            return false;

        if (turret.cost > this.currentMoney)
            return false;

        return true;
    }

    public void buyTurret(MyTurret turret)
    {
        this.currentMoney -= turret.cost;
    }

    void showCurrentMoney()
    {
        textMoney.text = "$" + currentMoney.ToString();
    }

    void showCurrentHP()
    {
        textHP.text = this.HP.ToString();
    }

    public int getCurrentMoney()
    {
        return this.currentMoney;
    }

    public void increaseMoney(int amount)
    {
        this.currentMoney += amount;
    }

    public void endGame()
    {
        //Debug.Log("END GAME");
        //Application.Quit();
    }
}
