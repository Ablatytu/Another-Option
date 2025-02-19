using System.Collections.Generic;
using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    public float speed = 5;

    [Header("Running")]
    public bool canRun = true;
    public bool IsRunning { get; private set; }
    public float runSpeed = 9;
    public KeyCode runningKey = KeyCode.LeftShift;
    public bool Switched;
    public Transform pointRay;
    public bool Landing;
    public GroundCheck ground;
    public Animator animator;
    public FirstPersonMovement nextMov;
    private Rigidbody rigidbody;
    public List<System.Func<float>> speedOverrides = new List<System.Func<float>>();



    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        ground = gameObject.GetComponentInChildren<GroundCheck>();
    }

    void FixedUpdate()
    {
        IsRunning = canRun && Input.GetKey(runningKey);

        float targetMovingSpeed = IsRunning ? runSpeed : speed;
        if (speedOverrides.Count > 0)
        {
            targetMovingSpeed = speedOverrides[speedOverrides.Count - 1]();
        }
        if (rigidbody.velocity.sqrMagnitude > 0.2f)
        {
            if (IsRunning)
            {
                animator.SetInteger("Run", 1);
                animator.SetBool("Idle", false);
            }
            else
            {
                animator.SetInteger("Run", 0);
                animator.SetBool("Idle", false);
            }
        }
        else
        {
            animator.SetBool("Idle", true);
        }

        Vector2 targetVelocity =new Vector2( Input.GetAxis("Horizontal") * targetMovingSpeed, Input.GetAxis("Vertical") * targetMovingSpeed);

        if(Switched)
        {
            rigidbody.velocity = transform.rotation * new Vector3(targetVelocity.x, -rigidbody.velocity.y, -targetVelocity.y);
        }
        else
        {
            if (Landing)
            {
                rigidbody.velocity = transform.rotation * new Vector3(0, targetVelocity.y, 0);
            }
            else
            {
                rigidbody.velocity = transform.rotation * new Vector3(targetVelocity.x, rigidbody.velocity.y, targetVelocity.y);
            }
        }
    }
}