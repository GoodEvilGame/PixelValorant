using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform shootPoint;
    public GameObject bullet;
    public Animator animator;

    private bool isShooting;
    private int health = 150;
    public float shootCooldown = 1f;
    private float nextFireTime = 0f;
    private bool CanFire { get { return Time.time > nextFireTime; } }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
        StartCoroutine(AnimController());
    }

    void Shoot()
    {
        isShooting = true;
        if(CanFire) 
        {
            nextFireTime = Time.time + shootCooldown;
        }
        else
        {
            isShooting = false;
            return;
        }

        GameObject newBullet = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
    }

    IEnumerator AnimController()
    {
        if (isShooting) { animator.SetBool("isShooting", true); yield return new WaitForSeconds(0.1f); animator.SetBool("isShooting", false); }
 
    }
}
