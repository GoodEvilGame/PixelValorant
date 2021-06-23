using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{
    public AudioClip viper;
    AudioSource audioSource;

    public Rigidbody2D rb;
    public Animator anim;
    public gunController gunController;

    public int health = 150;
    public int speed;
    public int jumpForce;
    public float dir;
    public bool jump;
    public bool onFloor;
    public bool isShooting;
    public bool isDead;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        speed = 7;
        jumpForce = 12;
    }

    // Update is called once per frame
    private void Update()
    {
        //Indentificando inputs direcionais e rotacionando o player de acordo com a dire��o
       if(isShooting == false && isDead == false)
        {
            Moving();
        }

        //Shooting
        if(Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Shoot());
        }
        
        AnimController(); 
        if(transform.localPosition.x <= -9)
        {
            audioSource.PlayOneShot(viper, 1.0F);
            SceneManager.LoadScene(1);
        }  

        if(health <= 0)
        {
            isDead = true;
            StartCoroutine(Death());
        }
                
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dir * speed, rb.velocity.y);
        if(jump == true && onFloor == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("floor"))
        {
            onFloor = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            Dano(10);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("floor"))
        {   
            onFloor = false;
        }
    }
    private void AnimController()
    {
        //////////////////////////////////
        if(dir != 0)
        {
            anim.SetBool("running", true);
        } 
        else
        {
            anim.SetBool("running", false);
        }
        //////////////////////////////////
        if(onFloor == false)
        {
            anim.SetBool("jumpping", true);
        }
        else
        {
            anim.SetBool("jumpping", false);
        }
        ///////////////////////////////////
        if(isShooting)
        {
            anim.SetBool("shootting", true);
        }
        else
        {
            anim.SetBool("shootting", false);
        }
        ////////////////////////////////////
        if (isDead)
        {
            anim.SetBool("dead", true);
        }
    }

    void Moving()
    {
        dir = Input.GetAxisRaw("Horizontal");
        Vector3 playerScale = transform.localScale;
        if (dir > 0)
        {
            playerScale.x = 3;
        }
        if (dir < 0)
        {
            playerScale.x = -3;
        }
        transform.localScale = playerScale;

        //Verificando input de pulo
        if (Input.GetKeyDown(KeyCode.W))
        {
            jump = true;
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            jump = false;
        }
    }

    IEnumerator Shoot()
    {
        isShooting = true;
        anim.SetBool("shootting", false);
        gunController.Shoot(transform.localScale.x);
        yield return new WaitForSeconds(0f);   
        isShooting = false;    
    }

    private void Dano(int dano)
    {
        health -= dano;
    }
    
    IEnumerator Death()
    {
        yield return new WaitForSecondsRealtime(1);
        SceneManager.LoadScene(0);
    }

}
