using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Animator animator;
    public gunController gunController;

    private bool isShooting = true;
    public int health = 150;
  
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health > 0)
        {
            gunController.Shoot(transform.localScale.x);
            StartCoroutine(AnimController());
        }
        else
        {
            animator.SetBool("dead", true);
            Debug.Log("moreu");
        }
        
    }


    IEnumerator AnimController()
    {
        if (isShooting) { animator.SetBool("isShooting", true); yield return new WaitForSeconds(0.1f); animator.SetBool("isShooting", false); }
 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("PlayerBullet"))
        {
            Dano(10);
        }
    }

    private void Dano(int dano)
    {
        health -= dano;
    }
}
