using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    
    public int speed;
    public int jumpForce;
    public float dir;
    public bool jump;
    public bool onFloor;
    // Start is called before the first frame update
    void Start()
    {
        speed = 7;
        jumpForce = 12;
    }

    // Update is called once per frame
    private void Update()
    {
        //Indentificando inputs direcionais e rotacionando o player de acordo com a direção
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
        
        AnimController();   
               
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dir * speed, rb.velocity.y);
        if(jump == true)
        {
            rb.velocity = Vector2.up * jumpForce;
            jump = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("floor"))
        {
            onFloor = true;
            Debug.Log("Enter");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("floor"))
        {
            onFloor = false;
            Debug.Log("Exit");
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
    }
}
