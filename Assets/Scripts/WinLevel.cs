using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WinLevel : MonoBehaviour
{
    public Text roundSurvive;

    private void OnEnable()
    {
        StartCoroutine(showRoundSurvive());
    }

    IEnumerator showRoundSurvive()
    {
        yield return new WaitForSeconds(0.1f);

        int roundSurvive = WaveSpawningControl.instance.getRoundNum();

        for (int i = 0; i <= roundSurvive; i++)
        {
            this.roundSurvive.text = i.ToString();
            yield return new WaitForSeconds(0.05f);
        }

    }
}
