using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    static public PlayerStatus instance;

    [Header("Attributes")]
    public int startMoney = 250;
    public int HP;
    public int levelIndex;

    [Header("UI Stuffs")]
    public GameObject gameOverCanvas;
    public GameObject winLevelCanvas;
    public Text textMoney;
    public Text textHP;
    public SceneFader sceneFader;
    public string nextLevelName;

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
        Time.timeScale = 1f;

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

    //True if we can. Vice versa
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

        Debug.Log("Waves Complete!!");

        gameOverCanvas.SetActive(true);
    }

    public void nextLevel()
    {
        PlayerPrefs.SetInt(LevelsManager.reachedLevelKeyword, levelIndex);
        sceneFader.fadeToNextScene(this.nextLevelName);
    }

    public void showWinLevelUI()
    {
        gameIsOver = true;
        this.winLevelCanvas.SetActive(true);
    }
}
