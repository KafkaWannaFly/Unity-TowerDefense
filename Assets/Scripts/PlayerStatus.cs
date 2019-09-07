using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    static public PlayerStatus instance;

    public int startMoney = 250;
    public int HP;

    public GameObject gameOver;
    public Text textMoney;
    public Text textHP;

    static public bool gameIsOver;
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

        gameIsOver = false;
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
        gameIsOver = true;

        gameOver.SetActive(true);
    }
}
