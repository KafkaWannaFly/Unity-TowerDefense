using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawningControl : MonoBehaviour
{
    public Transform spawningPoint;
    public Transform minionPrefab;

    public int totalWaveNumber = 3;
    public float timeBetweenWaves = 3f;

    float countDown = 2f;
    int minionsNum = 1;

    public Text countDownTimer;

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
        }

        countDown -= Time.deltaTime;
        if (countDown >= 0 && totalWaveNumber >0)
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
}
