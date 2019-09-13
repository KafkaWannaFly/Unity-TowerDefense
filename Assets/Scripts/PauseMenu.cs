using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public string mainMenuSceneName;
    public SceneFader sceneFader;

    private void Start()
    {
        pauseMenuUI.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pauseToggle();
        }
    }

    public void pauseToggle()
    {
        if(pauseMenuUI.activeSelf)
        {
            pauseMenuUI.SetActive(!pauseMenuUI.activeSelf);
            Time.timeScale = 1f;
        }
        else
        {
            pauseMenuUI.SetActive(!pauseMenuUI.activeSelf);
            Time.timeScale = 0f;
        }
    }

    public void openMainMenu()
    {
        Time.timeScale = 1f;
        sceneFader.fadeToNextScene(mainMenuSceneName);
    }

}
