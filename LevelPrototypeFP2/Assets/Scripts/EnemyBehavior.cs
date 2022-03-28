using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 2.0f;
    public float range;
    public GameObject[] enemies;

// Start is called before the first frame update
void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
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

        if (enemies.Length == 0)
        {
            LevelManager.enemiesDead = true;
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
        Debug.Log("Collided");
        if (other.CompareTag("Player"))
        {
            GetComponent<LevelManager>().LevelLost();
        }
    }
}
