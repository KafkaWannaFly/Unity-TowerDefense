using UnityEngine;
using UnityEngine.UI;
public class Minion : MonoBehaviour
{
    [Header("Attribute")]
    public float startSpeed = 20f;
    //[HideInInspector]
    public float speed;
    public int damage;
    public float HP;
    public int goldValue;

    [Header("Unity Setup Field")]
    public GameObject dieEffect;
    public Image heathBar;

    Transform target;
    int turnPointNum;
    float startHP;

    private void Start()
    {
        turnPointNum = 0;
        speed = startSpeed;
        startHP = HP;
    }

    private void Update()
    {
        navigateToEndPoint();
        updateHealthBar();
    }

    void navigateToEndPoint()
    {
        target = TurnPoints.turnPoints[turnPointNum].transform;

        Vector3 direction = target.position - this.transform.position;

        this.transform.Translate(direction.normalized * Time.deltaTime * speed, Space.World);

        if (Vector3.Distance(this.transform.position, target.position) <= 0.4f)
        {
            getNextTurnPoint();
        }
    }

    void getNextTurnPoint()
    {
        if (turnPointNum >= TurnPoints.turnPoints.Length - 1)
        {
            theEnd();
            return;
        }

        turnPointNum++;
        target = TurnPoints.turnPoints[turnPointNum].transform;
    }

    void theEnd()
    {
        PlayerStatus.instance.HP -= this.damage;
        Destroy(this.gameObject);
    }

    public void takeDamage(float amount)
    {
        HP -= amount;
        if(this.HP <= 0)
        {
            PlayerStatus.instance.increaseMoney(this.goldValue);
            die();
        }
    }

    public void takeSlowDebuff(float slowPercent)
    {
        this.speed = this.startSpeed * (1 - slowPercent);
    }

    void updateHealthBar()
    {
        this.heathBar.fillAmount = HP / startHP;
    }

    void die()
    {
        Destroy(this.gameObject);
        Instantiate(this.dieEffect, this.transform.position, Quaternion.identity);
    }
}
