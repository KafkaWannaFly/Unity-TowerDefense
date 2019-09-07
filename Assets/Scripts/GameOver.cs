using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text roundNum;

    private void OnEnable()
    {
        this.roundNum.text = WaveSpawningControl.instance.getRoundNum().ToString();
    }

    public void retryLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
