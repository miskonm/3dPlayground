using UnityEngine;
using Zenject;

public class PauseService : MonoBehaviour
{
    private PauseView pauseView;

    public bool IsPause { get; private set; }

    [Inject]
    public void Construct(PauseView pauseView)
    {
        this.pauseView = pauseView;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    private void TogglePause()
    {
        IsPause = !IsPause;

        Time.timeScale = IsPause ? 0 : 1;

        if (IsPause)
        {
            pauseView.Show();
        }
        else
        {
            pauseView.Hide();
        }
    }
}
