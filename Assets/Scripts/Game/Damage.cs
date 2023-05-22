using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D damage)
    {
        if (damage.transform.tag == "Player")
        {
            HealthManager.health--;
            if (HealthManager.health <= 0)
            {
                PlayerManager.isGameOver = true;
                AudioManager.instance.Play("GameOver");
            }
            else
            {
                StartCoroutine(GetHurt());
            }
        }
        IEnumerator GetHurt()
        {
            Physics2D.IgnoreLayerCollision(6, 8);
            GetComponent<Animator>().SetLayerWeight(1, 1);
            yield return new WaitForSeconds(3);
            GetComponent<Animator>().SetLayerWeight(1, 0);
            Physics2D.IgnoreLayerCollision(6, 8, false);
        }
    }
}
