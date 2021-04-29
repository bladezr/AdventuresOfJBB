using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public static bool gamepause = false;
    // Start is called before the first frame update
    public GameObject ui;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamepause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    void Pause()
    {
        ui.SetActive(true);
        Time.timeScale = 0f;
        gamepause = true;
    }
    void Resume() 
    {
        ui.SetActive(false);
        Time.timeScale = 1f;
        gamepause = false;
    }
    public void ResumeB()
    {
        ui.SetActive(false);
        Time.timeScale = 1f;
        gamepause = false;
    }

    public void Quit()
    {
        Application.Quit();
    }

}
