using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Small : MonoBehaviour
{
    Transform target;
    public Transform borderCheck;
    public int enemyHP = 100;
    public Animator animator;
    public Slider enemyHealthBar;

    void Start()
    {
        enemyHealthBar.value = enemyHP;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        Physics2D.IgnoreCollision(target.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }
    void Update()
    {

        if (target.position.x > transform.position.x)
            transform.localScale = new Vector2(0.45f, 0.45f);
        else
            transform.localScale = new Vector2(-0.45f, 0.45f);
    }
    public void TakeDamage(int damageAmount)
    {
        enemyHP -= damageAmount;
        enemyHealthBar.value = enemyHP;
        if (enemyHP > 0)
        {
            animator.SetTrigger("damage");
            animator.SetBool("isChasing", true);
        }
        else
        {
            animator.SetTrigger("death");
            gameObject.SetActive(false);
            GetComponent<CapsuleCollider2D>().enabled = false;
            enemyHealthBar.gameObject.SetActive(false);
            this.enabled = false;
        }
    }
}