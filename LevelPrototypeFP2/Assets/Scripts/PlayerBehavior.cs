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
        currentSpeed = baseSpeed;

    }

    private void Update()
    {
    }

    void FixedUpdate()
    {
        controlPlayer();
    }

    void controlPlayer()
    {


        float verticalMove = Input.GetAxis("Vertical");
        float horizontalMove = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizontalMove, 0.0f, verticalMove);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.AddForce(movement * currentSpeed, ForceMode.Impulse);
        }
        else
        {
            rb.velocity = movement * currentSpeed;

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            FindObjectOfType<LevelManager>().LevelLost();
            Destroy(gameObject);
        }
    }

}
