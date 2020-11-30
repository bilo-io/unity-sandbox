using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    Animator animator;
    [SerializeField]
    private float distanceToTarget;
    [SerializeField]
    private float speed;

    public EnemyState state = EnemyState.Idle;
    public Player target;
    public float idleSpeed = 1f;
    public float walkSpeed = 1.2f;
    public float chaseSpeed = 1.7f;
    public float chaseDistance = 10f;
    public float attackDistance = 1.5f;


    void Awake()
    {
        Animator thisAnimator = GetComponent<Animator>();

        animator = thisAnimator
            ? thisAnimator
            : GetComponentInChildren<Animator>();
        target = (Player)Object.FindObjectOfType<Player>();
    }

    void Start()
    {

    }

    void Update()
    {
        ManageState();
        ManageAction();
        ManageMovement();
    }

    void ManageState()
    {
        distanceToTarget = Vector3.Distance(target.transform.position, transform.position);

        if (distanceToTarget < chaseDistance)
        {
            if (distanceToTarget <= attackDistance)
            {
                state = EnemyState.Attack;
            }
            else
            {
                state = EnemyState.Chase;
            }
        }
        else
        {
            state = EnemyState.Idle;
        }

    }

    private void ManageAction()
    {
        switch (state)
        {
            case EnemyState.Idle:
                animator.SetBool("Idle", true);
                animator.SetBool("Chase", false);
                animator.SetBool("Attack", false);
                transform.LookAt(target.transform);
                speed = idleSpeed;
                break;
            case EnemyState.Chase:
                animator.SetBool("Idle", false);
                animator.SetBool("Chase", true);
                animator.SetBool("Attack", false);
                transform.LookAt(target.transform);
                speed = chaseSpeed;
                break;
            case EnemyState.Attack:
                animator.SetBool("Idle", false);
                animator.SetBool("Chase", false);
                animator.SetBool("Attack", true);
                transform.LookAt(target.transform);
                break;
            default:
                animator.SetBool("Idle", true);
                animator.SetBool("Chase", false);
                animator.SetBool("Attack", false);
                break;
        }
    }

    private void ManageMovement()
    {
        if(distanceToTarget > attackDistance)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
    }
}
