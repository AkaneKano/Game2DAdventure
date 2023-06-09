using UnityEngine;

public class ChaseSmall : StateMachineBehaviour
{
    Transform target;
    public float speed = 3;
    Transform borderCheck;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        borderCheck = animator.GetComponent<Small>().borderCheck;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector2 newPos = new Vector2(target.position.x, animator.transform.position.y);
        animator.transform.position =  Vector2.MoveTowards(animator.transform.position, newPos, speed * Time.deltaTime);
        if (Physics2D.Raycast(borderCheck.position, Vector2.down, 2) == false)
            animator.SetBool("isChasing", false);

        float distance = Vector2.Distance(target.position, animator.transform.position);
        if (distance < 1.5f)
            animator.SetBool("isAttacking", true);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

}
