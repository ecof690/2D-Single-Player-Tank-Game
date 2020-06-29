using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 20f;
    public int damage = 1;
    public Rigidbody2D rb;
    public GameObject impactEffect;


    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up * speed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        Destructable dest = collision.GetComponent<Destructable>();

        Debug.Log(collision.name);

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            //Instantiate(impactEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else if(dest != null)
        {
            dest.TakeDamage(damage);
            //Instantiate(impactEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else if (collision.tag != ("main_char"))
        {
            Destroy(gameObject);
        }

    }

}
