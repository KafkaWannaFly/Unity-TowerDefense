using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneFader : MonoBehaviour
{
    public Image img;
    public AnimationCurve fadeCurve;

    private void Start()
    {
        StartCoroutine(fadeIn());
    }

    IEnumerator fadeIn()
    {
        float alpha = 1f;

        while(alpha > 0f)
        {
            alpha -= Time.deltaTime;
            img.color = new Color(img.color.r, img.color.g, img.color.b, fadeCurve.Evaluate(alpha));

            yield return 0;
        }
    }

    IEnumerator fadeOut(string sceneName)
    {
        float alpha = 0f;

        while (alpha < 1f)
        {
            alpha += Time.deltaTime;
            img.color = new Color(img.color.r, img.color.g, img.color.b, fadeCurve.Evaluate(alpha));
            yield return 0;
        }

        SceneManager.LoadScene(sceneName);
    }

    public void fadeToNextScene(string sceneName)
    {
        Time.timeScale = 1f;
        StartCoroutine(fadeOut(sceneName));
    }
}
