using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    public Button pause;
    public static bool isPaused = false;
    public GameObject pauseMenuUI;
    
    void Start()
    {
        pause.onClick.AddListener(TaskOnClick);//on click pause
    }

    void TaskOnClick()
    {
        if (isPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void Options()
    {
        Debug.Log("Options Clicked");
    }

    public void Quit()
    {
        Debug.Log("Quit Clicked");
    }
}

