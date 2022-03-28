using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehavior : MonoBehaviour
{
    CharacterController _controller;
    public float moveSpeed;
    public float gravity = 9.81f;
    Vector3 input, moveDirection;
    public float airControl = 10f;
    public Slider healthSlide;
    Animator anim;
    int playerHealth = 100;
    public AudioClip sword;
    public AudioClip hurt;

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
                    AudioSource.PlayClipAtPoint(sword, transform.position);

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
        if(playerHealth > dmg)
        {
            playerHealth = playerHealth - dmg;
            AudioSource.PlayClipAtPoint(hurt, transform.position);
            healthSlide.value = playerHealth;

        }
        else
        {
            playerHealth = 0;
            healthSlide.value = playerHealth;
            FindObjectOfType<LevelManager>().LevelLost();
        }
    }
}
