using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    Idle,
    Chase,
    Attack
}

public class Enemy : MonoBehaviour
{
    [SerializeField]
    Animator animator;
    [SerializeField]
    private float distanceToTarget;
    [SerializeField]
    private float speed;

    public EnemyState state = EnemyState.Idle;
    public VirtualMuseum.Player target;
    public GameObject subject;

    // public CharacterController controller;
    public Rigidbody body;

    public float idleSpeed = 1f;
    public float walkSpeed = 1.2f;
    public float chaseSpeed = 1.7f;
    public float chaseDistance = 10f;
    public float attackDistance = 1.5f;


    void Awake()
    {
        // Animator thisAnimator = subject.gameObject.GetComponent<Animator>();

        // animator = thisAnimator
        //     ? thisAnimator
        //     : GetComponentInChildren<Animator>();
        target = (VirtualMuseum.Player)Object.FindObjectOfType<VirtualMuseum.Player>();
        body.constraints = RigidbodyConstraints.None;
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

    private void FixedUpdate() {
      {
        ManageMovement();
      }
    }

    void ManageState()
    {
        distanceToTarget = Vector3.Distance(target.transform.position, subject.transform.position);

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
              if(animator != null) {
                  animator.SetBool("Idle", true);
                  animator.SetBool("Chase", false);
                  animator.SetBool("Attack", false);
              }
                speed = idleSpeed;
                break;
            case EnemyState.Chase:
              if(animator != null) {
                  animator.SetBool("Idle", false);
                  animator.SetBool("Chase", true);
                  animator.SetBool("Attack", false);
                }
                speed = chaseSpeed;
                break;
            case EnemyState.Attack:
              if(animator != null) {
                animator.SetBool("Idle", false);
                animator.SetBool("Chase", false);
                animator.SetBool("Attack", true);
              }
                break;
            default:
            if(animator != null) {
                animator.SetBool("Idle", true);
                animator.SetBool("Chase", false);
                animator.SetBool("Attack", false);
            }
                break;
        }
    }

    private void ManageMovement()
    {
        subject.transform.LookAt(target.transform);
        if(distanceToTarget > attackDistance)
        {
            Vector3 direction = (subject.transform.position - target.transform.position).normalized;
            var displacement = direction * Time.deltaTime * speed;
            body.MovePosition(displacement);
            // body.velocity = displacement;
            // controller.Move(displacement);
            // subject.transform.Translate(displacement);
        } else {
          // body.velocity = Vector3.zero;
        }
    }
}
