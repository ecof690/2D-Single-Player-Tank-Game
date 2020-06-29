using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Enemy : MonoBehaviour
{

    public float speed = 20f;
    public int damage2 = 1;
    public Rigidbody2D rb;
    public GameObject impactEffect;


    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up * speed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Main_chr chr = collision.GetComponent<Main_chr>();
        Destructable dest = collision.GetComponent<Destructable>();

        Debug.Log(collision.name);

        if (chr != null)
        {
            chr.TakeDamage_chr(damage2);
            //Instantiate(impactEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else if (dest != null)
        {
            dest.TakeDamage(damage2);
            //Instantiate(impactEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else if (collision.tag != ("Enemy"))
        {
            Destroy(gameObject);
        }

    }



}
