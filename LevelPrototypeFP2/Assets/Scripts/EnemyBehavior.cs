using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 2.0f;
    public float range;

// Start is called before the first frame update
void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) <= range)
        {
            RotateEnemy();
            FollowPlayer();
        }
    }

    void RotateEnemy()
    {
        transform.Rotate(Vector3.forward * 360 * Time.deltaTime);

    }

    void FollowPlayer()
    {
        transform.LookAt(player);
        transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<PlayerBehavior>().TakeDamage(10);
        }
    }
}
