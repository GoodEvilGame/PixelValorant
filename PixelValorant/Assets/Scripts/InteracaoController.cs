using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteracaoController : MonoBehaviour
{
    bool colisor;
    public GameObject BoxConversation;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
      if(colisor == true && Input.GetKeyDown(KeyCode.E)){
        BoxConversation.SetActive(true);
        BoxConversation.GetComponent<handler>().nextFala();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string other = collision.gameObject.tag;
        switch(other)
        {
            case "Enemy":
            colisor = true;
                break;
            default:
                break;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        string other = collision.gameObject.tag;
        switch(other)
        {
            case "Enemy":
            colisor = false;
                break;
            default:
                break;
        }

}
}
