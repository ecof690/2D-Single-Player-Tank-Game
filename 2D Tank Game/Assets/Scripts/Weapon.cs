using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform firepoint;
    public GameObject bulletPrefab;

    private AudioSource mAudioSrc;

    public float fireRate = 0.5F;
    private float nextFire = 0.0F;

    private void Start()
    {
        mAudioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Space))&& Time.time > nextFire)
        {
            mAudioSrc.Play();
            shoot();
            nextFire = Time.time + fireRate;
        }

    }

    public void shoot()
    {
        Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
    }


}
