using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private CharacterController controller;

    [Header("Movement")]
    [SerializeField] private float moveSpeed;

    [Header("Jump")]
    [SerializeField] private float jumpHeight;

    [Header("Gravity")]
    [SerializeField] private float gravityScale = 2f;

    [Header("Rotation")]
    [SerializeField] private float rotateSpeed;

    [Header("Resetting")]
    [SerializeField] private float toStartDuration;

    [SerializeField] private Animator animator;

    private Transform cameraTransform;
    private float gravity;
    private Vector3 startPosition;
    private bool isMoving;

    private void Awake()
    {
        startPosition = transform.position;
        isMoving = true;
    }

    private void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        if (!isMoving) return;

        // Rotate();
        Move();
    }

    private void Rotate()
    {
        var horizontal = Input.GetAxis("Mouse X");

        transform.Rotate(Vector3.up, rotateSpeed * horizontal * Time.deltaTime);
    }

    private void Move()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        var forward = cameraTransform.forward;
        forward.y = 0;
        forward.Normalize();
        
        var right = cameraTransform.right;
        right.y = 0;
        right.Normalize();
        
        var moveDirection = forward * vertical + right * horizontal;

        var isRunning = IsRunning();
        if (isRunning)
        {
            transform.rotation = Quaternion.LookRotation(moveDirection);
            // animator.SetFloat("Vertical", vertical);
            // animator.SetFloat("Horizontal", horizontal);
        }

        animator.SetBool("IsRunning", isRunning);

        if (moveDirection.sqrMagnitude > 1f)
        {
            moveDirection.Normalize();
        }

        var moveDelta = moveDirection * (moveSpeed * Time.deltaTime);

        if (controller.isGrounded)
        {
            gravity = -0.1f;

            if (Input.GetButtonDown("Jump"))
            {
                gravity = jumpHeight;
                animator.SetTrigger("Jump");
            }
        }
        else
        {
            gravity += Physics.gravity.y * gravityScale * Time.deltaTime;
        }

        moveDelta.y = gravity;

        var animationGravity = 0;

        if (gravity > 0)
        {
            animationGravity = 1;
        }
        else if (gravity < -0.25f)
        {
            animationGravity = -1;
        }
        else
        {
            animationGravity = 0;
        }
        
        animator.SetInteger("Gravity", animationGravity);

        controller.Move(moveDelta);

        bool IsRunning()
        {
            return Mathf.Abs(horizontal) + Mathf.Abs(vertical) > 0;
        }
    }

    public void ResetPosition()
    {
        isMoving = false;

        transform
               .DOMove(startPosition, toStartDuration)
               .SetEase(Ease.Flash)
               .OnComplete(() => isMoving = true);
    }
}
