using System;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private Animator unitAnimator;
    private Vector3 targetPosition;
    
    public void Move(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
    }

    private void Awake()
    {
        targetPosition = transform.position;
    }

    private void Update()
    {
        unitAnimator.SetBool("IsWalking", true);
        float stopDistance = 0.1f;
        if (Vector3.Distance(transform.position, targetPosition) > stopDistance)
        {
            Vector3 moveDirection = (targetPosition - transform.position).normalized;
            float moveSpeed = 4f;
            transform.position += moveDirection * (moveSpeed * Time.deltaTime); 
            unitAnimator.SetBool("IsWalking", true);
            transform.forward = Vector3.Lerp(transform.forward, moveDirection, Time.deltaTime * 10f);
        }
        else
        {
            unitAnimator.SetBool("IsWalking", false);
        }
    }
}