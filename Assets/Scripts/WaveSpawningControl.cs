using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawningControl : MonoBehaviour
{
    static public WaveSpawningControl instance;

    public Transform spawningPoint;
    public Transform minionPrefab;

    public int totalWaveNumber;
    public float timeBetweenWaves;

    float countDown;
    int minionsNum;
    int roundNum;

    public Text countDownTimer;

    private void Awake()
    {
        if (instance != null)
            return;
        instance = this;
    }

    private void Start()
    {
         countDown = 2f;
         minionsNum = 1;
         roundNum = 0;
    }

    private void Update()
    {
        if (countDown <= 0 && totalWaveNumber > 0)
        {
            StartCoroutine(spawnTheMinions(minionsNum));
            //spawnTheMinions(minionsNum);
            countDown = timeBetweenWaves;
            minionsNum++;
            timeBetweenWaves++;
            totalWaveNumber--;
            roundNum++;
        }

        countDown -= Time.deltaTime;
        if (countDown >= 0 && totalWaveNumber > 0)
        {
            countDownTimer.text = Mathf.Round(countDown).ToString();
        }
      
    }

    IEnumerator spawnTheMinions(int minionNum)
    {
        for (int i = 0; i < minionNum; i++)
        {
            Instantiate(minionPrefab, spawningPoint.position, spawningPoint.rotation);
            yield return new WaitForSeconds(0.2f);
        }
    }

    public int getRoundNum()
    {
        return this.roundNum;
    }
}
