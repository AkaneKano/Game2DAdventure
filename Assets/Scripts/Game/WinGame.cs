using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGame : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D nextlevel)
    {
        if (nextlevel.tag == "Player")
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
