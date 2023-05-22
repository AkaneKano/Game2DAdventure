using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHealth : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        HealthManager.health++;
        if (collision.tag == "Player")
        {
            gameObject.SetActive(false);
        }
    }
}
