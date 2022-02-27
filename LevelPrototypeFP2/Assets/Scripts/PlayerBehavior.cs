using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float baseSpeed;
    Rigidbody rb;
    float jumpAmount = 2;
    float currentSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    private void Update()
    {
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = baseSpeed * 2;
        }
        else
        {
            currentSpeed = baseSpeed;
        }
        controlPlayer();

    }

    void controlPlayer()
    {
        float verticalMove = Input.GetAxis("Vertical");
        float horizontalMove = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizontalMove, 0.0f, verticalMove);
        rb.AddForce(movement * currentSpeed);

        if (Input.GetAxis("Jump") == 1)
        {
            if (transform.position.y < 2f)
            {
                Vector3 jump = new Vector3(0, jumpAmount, 0);
                rb.AddForce(jump, ForceMode.Impulse);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }

}
