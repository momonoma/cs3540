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
    public Animator anim;
    public GameObject gunTip;

    public enum EnemyState
    {
        Idle,
        Aimed,
        Attack,
        Move
    }

    public EnemyState currentState;

    // Start is called before the first frame update
    void Start()
    {
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        anim = GetComponent<Animator>();

        currentState = EnemyState.Idle;

        gunTip = GameObject.Find("GunTip");
    }

    // Update is called once per frame
    void Update()
    {
        switch(currentState)
        {
            case EnemyState.Idle:
                UpdateIdleState();
                break;
            case EnemyState.Aimed:
                UpdateAimedState();
                break;
            case EnemyState.Attack:
                UpdateAttackState();
                break;
            case EnemyState.Move:
                UpdateMoveState();
                break;
        }
    }

    void UpdateIdleState()
    {
        anim.SetInteger("animState", 0);
    }

    void UpdateAimedState()
    {
        anim.SetInteger("animState", 1);
    }

    void UpdateAttackState()
    {
        anim.SetInteger("animState", 2);
    }

    void UpdateMoveState()
    {
        anim.SetInteger("animState", 3);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, alertDistance);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackDistance);
    }
}
