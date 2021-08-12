using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseService : MonoBehaviour
{
    public PauseView pauseView;
    
    private bool isPause;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    private void TogglePause()
    {
        isPause = !isPause;

        Time.timeScale = isPause ? 0 : 1;

        if (isPause)
        {
            pauseView.Show();
        }
        else
        {
            pauseView.Hide();
        }
    }
}
