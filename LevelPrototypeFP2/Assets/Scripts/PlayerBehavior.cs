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
    float RotateSpeed = 80f;
    Animator anim;
    int playerHealth = 100;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth > 0)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            if (moveHorizontal != 0 || moveVertical != 0)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    anim.SetInteger("Movement", 3);

                }

                if (Input.GetKey(KeyCode.LeftShift))
                {
                    anim.SetInteger("Movement", 2);
                    moveSpeed = 6;
                }
                else
                {
                    anim.SetInteger("Movement", 1);
                }

                input = new Vector3(moveHorizontal, 0, moveVertical);
                input.Normalize();
                moveDirection = input;
                moveDirection.y -= gravity * Time.deltaTime;
                _controller.Move(moveDirection * Time.deltaTime);
                if (moveDirection != Vector3.zero)
                {
                    transform.forward = moveDirection;
                }

            }
            else
            {
                anim.SetInteger("Movement", 0);
            }

            if (Input.GetKey(KeyCode.E))
            {
                anim.SetInteger("Movement", 3);

            }
        }
        else
        {
            anim.SetInteger("Movement", 4);
        }

    }

    public void TakeDamage(int dmg)
    {
        playerHealth = playerHealth - dmg;
        Debug.Log(playerHealth);
    }
}
