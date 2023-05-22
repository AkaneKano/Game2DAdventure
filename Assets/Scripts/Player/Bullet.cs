using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Bullet : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            AudioManager.instance.Play("EnemyDamage");
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if(collision.tag == "Zombie")
        {
            collision.GetComponent<Zombie>().TakeDamage(25);
            Destroy(gameObject);
        }
        if (collision.tag == "Small")
        {
            collision.GetComponent<Small>().TakeDamage(25);
            Destroy(gameObject);
        }
    }
}
