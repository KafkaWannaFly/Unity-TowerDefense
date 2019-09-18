using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawningControl : MonoBehaviour
{
    static public WaveSpawningControl instance;
    static public int enemyAlive = 0;

    public Transform spawningPoint;

    public float timeBetweenWaves;

    public Wave[] wavesBlueprint;

    float countDown;
    int roundNum;

    public Text countDownTimer;

    private void Awake()
    {
        if (instance != null)
            return;
        instance = this;

        this.roundNum = 0;
    }

    private void Start()
    {
        countDown = timeBetweenWaves;
    }

    private void Update()
    {
        if (enemyAlive > 0)
            return;

        showCountDownTimer();

        if (countDown <= 0 && roundNum < wavesBlueprint.Length)
        {
            StartCoroutine(spawnTheMinions(this.wavesBlueprint[roundNum]));
            enemyAlive = this.wavesBlueprint[roundNum].enemyAmount;
            roundNum++;
            countDown = timeBetweenWaves;
        }
         countDown -= Time.deltaTime;

        if(roundNum == wavesBlueprint.Length)
        {
            countDown = 0;
            //Level complete here!

            if(enemyAlive == 0)
            {
                PlayerStatus.instance.showWinLevelUI();
            }
        }
    }

    IEnumerator spawnTheMinions(Wave wave)
    {
        for (int i=0; i<wave.enemyAmount; i++)
        {
            Instantiate(wave.enemyPrefab, this.spawningPoint.position, Quaternion.identity);
            yield return new WaitForSeconds(1f / wave.spawningRate);
        }
    }

    public int getRoundNum()
    {
        return this.roundNum;
    }

    void showCountDownTimer()
    {
        if (countDown < 0)
        {
            countDown = 0;
        }
        countDownTimer.text = string.Format("{0:00.00}", countDown);
    }
}
