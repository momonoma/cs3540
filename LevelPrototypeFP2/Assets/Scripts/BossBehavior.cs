using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    Animator anim;
    int TotalHealth = 100;
    Transform player;
    int range = 10;
    public GameObject projectile;
    [SerializeField] private float cooldown = 5;
    private float cooldownTimer;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (TotalHealth > 0)
        {
            transform.LookAt(player);
            TargetedAttack();
        }
        else
        {
            anim.SetInteger("AttackPattern", 3);
            LevelManager.bossDead = true;
        }
    }

    public void TakeDamage(int dmg)
    {
        int tempHealth = TotalHealth - dmg;
        TotalHealth = tempHealth;
        Debug.Log(TotalHealth);
    }

    void TargetedAttack()
    {
        cooldownTimer -= Time.deltaTime;

        if (cooldownTimer > 0) return;

        cooldownTimer = cooldown;

        GameObject tempBullet = Instantiate(projectile, gameObject.transform.position, gameObject.transform.rotation);
        tempBullet.transform.LookAt(player);
        Rigidbody tempRigidBodyBullet = tempBullet.GetComponent<Rigidbody>();
        tempRigidBodyBullet.AddForce(tempRigidBodyBullet.transform.forward * 50f, ForceMode.Impulse);
        Destroy(tempBullet, 2f);
    }
}
