using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int speed = 5;
    protected bool isMoving = false;

    Rigidbody2D rb2d;
    float h, v;
    enum Direction { Up, Down, Left, Right };
    Direction[] direction = { Direction.Up, Direction.Down, Direction.Left, Direction.Right };

    public Transform firepoint;
    public GameObject bulletPrefab;

    private AudioSource mAudioSrc2;


    public float fireRate = 0.5F;
    private float nextFire = 0.0F;

    private void Start()
    {
        mAudioSrc2 = GetComponent<AudioSource>();
        rb2d = GetComponent<Rigidbody2D>();
        RandomDirection();
        Invoke("Fire", Random.Range(1f, 5f));
    }
    public void RandomDirection()
    {
        Direction selection = direction[Random.Range(0, 4)];
        if (selection == Direction.Up)
        {
            v = 1;
            h = 0;
        }
        if (selection == Direction.Down)
        {
            v = -1;
            h = 0;
        }
        if (selection == Direction.Right)
        {
            v = 0;
            h = 1;
        }
        if (selection == Direction.Left)
        {
            v = 0;
            h = -1;
        }
    }


    void Fire()
    {
        print("Fire");
        shoot2();
        Invoke("Fire", Random.Range(1f, 5f));
    }

    void shoot2()
    {
        mAudioSrc2.Play();
        Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        nextFire = Time.time + fireRate;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        RandomDirection();
    }
    void FixedUpdate()
    {
        if (v != 0 && isMoving == false) StartCoroutine(MoveVertical(v, rb2d));
        else if (h != 0 && isMoving == false) StartCoroutine(MoveHorizontal(h, rb2d));
    }

    protected IEnumerator MoveHorizontal(float movementHorizontal, Rigidbody2D rb2d)
    {
        isMoving = true;

        transform.position = new Vector2(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y));

        Quaternion rotation = Quaternion.Euler(0, 0, -movementHorizontal * 90f);
        transform.rotation = rotation;

        float movementProgress = 0f;
        Vector2 movement, endPos;

        while (movementProgress < Mathf.Abs(movementHorizontal))
        {
            movementProgress += speed * Time.deltaTime;
            movementProgress = Mathf.Clamp(movementProgress, 0f, 1f);
            movement = new Vector2(speed * Time.deltaTime * movementHorizontal, 0f);
            endPos = rb2d.position + movement;

            if (movementProgress == 1) endPos = new Vector2(Mathf.Round(endPos.x), endPos.y);
            rb2d.MovePosition(endPos);

            yield return new WaitForFixedUpdate();
        }

        isMoving = false;
    }

    protected IEnumerator MoveVertical(float move_Vert, Rigidbody2D rb2d)
    {
        isMoving = true;

        transform.position = new Vector2(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y));

        Quaternion rotation;

        if (move_Vert < 0)
        {
            rotation = Quaternion.Euler(0, 0, move_Vert * 180f);
        }
        else
        {
            rotation = Quaternion.Euler(0, 0, 0);
        }
        transform.rotation = rotation;

        float move_Prog = 0f;
        Vector2 endPos, movement;

        while (move_Prog < Mathf.Abs(move_Vert))
        {

            move_Prog += speed * Time.deltaTime;
            move_Prog = Mathf.Clamp(move_Prog, 0f, 1f);

            movement = new Vector2(0f, speed * Time.deltaTime * move_Vert);
            endPos = rb2d.position + movement;

            if (move_Prog == 1) endPos = new Vector2(endPos.x, Mathf.Round(endPos.y));
            rb2d.MovePosition(endPos);
            yield return new WaitForFixedUpdate();

        }

        isMoving = false;

    }

    //----------------------------------//

    public int health = 1;
    public GameObject deathEffect;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }

    }

    void Die()
    {
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }


}
