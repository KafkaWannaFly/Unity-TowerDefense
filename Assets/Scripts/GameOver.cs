using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOver : MonoBehaviour
{
    public Text roundNum;
    public SceneFader sceneFader;

    private void OnEnable()
    {
        //this.roundNum.text = WaveSpawningControl.instance.getRoundNum().ToString();
        StartCoroutine(showRoundSurvive());
    }

    public void retryLevel()
    {
        sceneFader.fadeToNextScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator showRoundSurvive()
    {
        int roundSurvive = WaveSpawningControl.instance.getRoundNum();

        yield return new WaitForSeconds(0.1f);
        
        for(int i=0; i <= roundSurvive; i++)
        {
            this.roundNum.text = i.ToString();
            yield return new WaitForSeconds(0.05f);
        }
    }
}
