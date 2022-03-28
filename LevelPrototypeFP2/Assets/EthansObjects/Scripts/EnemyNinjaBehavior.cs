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
    public float bulletSpeed = 20f;

    float distanceToPlayer;
    float elapsedTime = 0f;

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
        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        switch (currentState)
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

        elapsedTime += Time.deltaTime;
    }

    void UpdateIdleState()
    {
        anim.SetInteger("animState", 0);
        if(distanceToPlayer <= alertDistance)
        {
            currentState = EnemyState.Aimed;
        }
    }

    void UpdateAimedState()
    {
        anim.SetInteger("animState", 1);
        FaceTarget(player.transform.position);

        if(distanceToPlayer <= attackDistance)
        {
            currentState = EnemyState.Attack;
        }
        else if(distanceToPlayer > alertDistance)
        {
            currentState = EnemyState.Idle;
        }
    }

    void UpdateAttackState()
    {
        anim.SetInteger("animState", 2);
        FaceTarget(player.transform.position);

        EnemyAttack();

        if(distanceToPlayer > attackDistance)
        {
            currentState = EnemyState.Aimed;
        }
        else if(distanceToPlayer > alertDistance)
        {
            currentState = EnemyState.Idle;
        }
    }

    void UpdateMoveState()
    {
        anim.SetInteger("animState", 3);
    }

    void FaceTarget(Vector3 target)
    {
        Vector3 directionToTarget = (target - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(directionToTarget);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 10 * Time.deltaTime);
    }

    void EnemyAttack()
    {
        if(elapsedTime >= attackRate)
        {
            var animDuration = anim.GetCurrentAnimatorStateInfo(0).length;
            Invoke("Shoot", animDuration);
            elapsedTime = 0.0f;
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, gunTip.transform.position, gunTip.transform.rotation);
        var _rb = bullet.GetComponent<Rigidbody>();
        _rb.AddForce(transform.forward * bulletSpeed, ForceMode.VelocityChange);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, alertDistance);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackDistance);
    }
}
