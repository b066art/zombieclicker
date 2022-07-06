using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]

public class AIMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 200f;
    [SerializeField] private float rotationSpeed = 200f;
    [SerializeField] private float minWalkTime = 1f;
    [SerializeField] private float maxWalkTime = 3f;

    private bool isPatrolling = false;
    private bool isRotatingLeft = false;
    private bool isRotatingRight = false;
    private bool isWalking = false;

    private Animator animator;
    private Rigidbody rb;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if(!isPatrolling)
        {
            StartCoroutine(Patrol());
        }
        
        if(isRotatingLeft)
        {
            transform.Rotate(transform.up * -rotationSpeed * Time.deltaTime);
        }

        if(isRotatingRight)
        {
            transform.Rotate(transform.up * rotationSpeed * Time.deltaTime);
        }

        if(isWalking)
        {
            rb.AddForce(transform.forward * movementSpeed);
            animator.SetBool("isMoving", true);
        }
        
        if(!isWalking)
        {
            animator.SetBool("isMoving", false);
        }
    }

    private IEnumerator Patrol()
    {
        int rotateDirection = Random.Range(0, 2);
        float rotationTime = Random.value;
        float walkTime = Random.Range(minWalkTime, maxWalkTime);

        isPatrolling = true;
        isWalking = true;

        yield return new WaitForSeconds(walkTime);

        isWalking = false;

        if(rotateDirection == 0)
        {
            isRotatingLeft = true;
            yield return new WaitForSeconds(rotationTime);
            isRotatingLeft = false;
        }

        if(rotateDirection == 1)
        {
            isRotatingRight = true;
            yield return new WaitForSeconds(rotationTime);
            isRotatingRight = false;
        }

        isPatrolling = false;
    }
}
