using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text roundNum;
    public SceneFader sceneFader;

    private void OnEnable()
    {
        this.roundNum.text = WaveSpawningControl.instance.getRoundNum().ToString();
    }

    public void retryLevel()
    {
        sceneFader.fadeToNextScene(SceneManager.GetActiveScene().name);
    }
}
