using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    CharacterController _controller;
    public float moveSpeed;
    public float gravity = 9.81f;
    public float jumpHeight = 5f;
    Vector3 input, moveDirection;
    public float airControl = 10f;
    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        input = transform.right * moveHorizontal + transform.forward * moveVertical;
        input *= moveSpeed;
        if (_controller.isGrounded)
        {
            moveDirection = input;
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = Mathf.Sqrt(2 * gravity * jumpHeight);
            }
            else
            {
                moveDirection.y = 0.0f;
            }
        }
        else
        {
            input.y = moveDirection.y;
            moveDirection = Vector3.Lerp(moveDirection, input, Time.deltaTime * airControl);
        }
        moveDirection.y -= gravity * Time.deltaTime;
        _controller.Move(moveDirection * Time.deltaTime);

    }
}
