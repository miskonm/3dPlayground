using System;
using Playground.Game;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject bulletPrefab;

    private PlayerMovement playerMovement;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Attack();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Coin>(out var coin))
            coin.Collect();
    }

    public void DoDamage()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        // playerMovement.ResetPosition();
    }

    private void Attack()
    {
        animator.SetTrigger("Attack");
    }
}
