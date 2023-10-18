using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Attributes
    private Vector3 moveAmount;
    [SerializeField] float moveSpeed;
    [SerializeField] float rotateSpeed;

    void Start()
    {
        
    }

    void Update()
    {
        Move();
        CarRotation();
    }

    private void Move()
    {
        float xValue = Input.GetAxisRaw("Horizontal") * Time.deltaTime * moveSpeed;
        float zValue = Input.GetAxisRaw("Vertical") * Time.deltaTime * moveSpeed;

        moveAmount = new Vector3(xValue,0f, zValue);

        transform.position += moveAmount;
    }
    
    private void CarRotation()
    {
        if (moveAmount.magnitude > Mathf.Epsilon)
        {
            if (moveAmount != Vector3.zero)
            {
                Quaternion newRot = Quaternion.LookRotation(moveAmount); // xoay theo huong moveInput cua nguoi dung
                transform.rotation = Quaternion.Slerp(transform.rotation, newRot, rotateSpeed * Time.deltaTime); // Random muc do xoay
            }
        }
    }
}
