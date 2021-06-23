using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class gunController : MonoBehaviour
{
    public Bullet bullet;
    public Transform shootPoint;
    public string tagE;

    public float shootCooldown;
    private float nextFireTime;
    private bool CanFire { get { return Time.time > nextFireTime; } }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot(float scaleX)
    {
        float direction = scaleX / (Math.Abs(scaleX));
        if (CanFire)
        {
            nextFireTime = Time.time + shootCooldown;
        }
        else
        {
            return;
        }

        bullet.TagE = tagE;
        bullet.Direction = direction;
        Instantiate(bullet, shootPoint.position, shootPoint.rotation);
    }
}
