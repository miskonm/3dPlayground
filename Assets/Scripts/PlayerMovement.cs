using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    
    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        transform.position += transform.forward * (vertical * speed * Time.deltaTime);
        transform.Rotate(Vector3.up, horizontal * rotationSpeed * Time.deltaTime);
    }
}
