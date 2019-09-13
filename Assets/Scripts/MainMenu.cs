using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public string startLevelName;
    public SceneFader sceneFader;

    public void startTheGame()
    {
        sceneFader.fadeToNextScene(startLevelName);
    }
}
