using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Bullet : MonoBehaviour
{   
    public AudioClip vandal;
    AudioSource audioSource;
    public float speed = 40f;
    public Rigidbody2D rb;
    public string TagE;
    public float Direction;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(vandal, 1.0F);
        rb.velocity =  new Vector2(Direction * speed, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag($"{TagE}") || collision.gameObject.CompareTag("plataform"))
        {
            Destroy(gameObject);
        }
    }


}
