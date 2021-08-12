using System;
using Playground.Game;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private PlayerMovement playerMovement;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Coin>(out var coin))
            coin.Collect();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Attack();
    }

    private void Attack()
    {
        animator.SetTrigger("Attack");
    }

    public void DoDamage()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        // playerMovement.ResetPosition();
    }
}
