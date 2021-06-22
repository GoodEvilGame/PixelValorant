using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Animator animator;
    public gunController gunController;

    private bool isShooting = true;
    private int health = 150;
  
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gunController.Shoot(transform.localScale.x);
        StartCoroutine(AnimController());
    }


    IEnumerator AnimController()
    {
        if (isShooting) { animator.SetBool("isShooting", true); yield return new WaitForSeconds(0.1f); animator.SetBool("isShooting", false); }
 
    }
}
