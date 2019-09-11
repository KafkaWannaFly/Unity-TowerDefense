using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;

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

}
