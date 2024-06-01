using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private Animator unitAnimator;
    private Vector3 targetPosition;
    
    private void Move(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
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
            transform.forward = moveDirection;
        }
        else
        {
            unitAnimator.SetBool("IsWalking", false);
        }
        if (Input.GetMouseButtonDown(0))
        {
            
            Move(MouseWorld.GetPosition());
            Debug.Log("Clicked!" + MouseWorld.GetPosition());
        }
        
    }
}