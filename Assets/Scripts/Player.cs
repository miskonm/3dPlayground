using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerMovement playerMovement;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    public void DoDamage()
    {
        playerMovement.ResetPosition();
    }
}
