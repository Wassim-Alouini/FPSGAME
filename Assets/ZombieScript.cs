using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieScript : MonoBehaviour
{

    Vector3 direction;
    Transform playerTransform;
    Rigidbody rb;
    Animator animator;
    public float speed = 0.5f;
    HealthManager playerHealthManager;
    bool dealDamage;
    [SerializeField] float damage;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        playerTransform = GameObject.Find("Player").transform;
        playerHealthManager = playerTransform.GetComponent<HealthManager>();
    }
    private void Update()
    {
        if (!playerTransform)
        {
            direction = Vector3.zero;
            return;
        }

        direction = playerTransform.position - transform.position;
        direction.y = 0;
        rb.rotation = Quaternion.LookRotation(direction);
        rb.angularVelocity = Vector3.zero;
        rb.MovePosition(rb.position + direction.normalized * speed * Time.deltaTime);

        if(dealDamage && playerHealthManager)
        {
            playerHealthManager.TakeDamage(20 * Time.deltaTime);
        }
        animator.SetFloat("MoveSpeed", 1);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
            dealDamage = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Player")
            dealDamage = false;
    }
}
