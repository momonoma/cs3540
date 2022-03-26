using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNinjaBehavior : MonoBehaviour
{
    public GameObject player;
    public GameObject bulletPrefab;
    public float attackDistance = 10f;
    public float alertDistance = 20f;
    public float attackRate = 2f;


    // Start is called before the first frame update
    void Start()
    {
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
