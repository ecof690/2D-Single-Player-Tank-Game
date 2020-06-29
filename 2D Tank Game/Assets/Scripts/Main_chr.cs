using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_chr : MonoBehaviour
{
    public int health = 1;
    public GameObject deathEffect;
    public GameObject gameover_UI;
    public void TakeDamage_chr(int damage2)
    {
        health -= damage2;

        if (health <= 0)
        {
            GetComponent<Main_chr_movement>().enabled = false;
            //Instantiate(deathEffect, transform.position, Quaternion.identity);
            Invoke("Die", 3.0f);
        }

    }

    void Die()
    {
        gameover_UI.SetActive(true);
        GetComponent<Main_chr_movement>().enabled = true;
        Destroy(gameObject);
    }
}
