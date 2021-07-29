using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private PlayerMovement playerMovement;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    public void DoDamage()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        // playerMovement.ResetPosition();
    }
}
