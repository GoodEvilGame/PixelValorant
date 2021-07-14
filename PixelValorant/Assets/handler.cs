using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class handler : MonoBehaviour
{

    int stage = 0;

    string[] nomeMsg = { "Killjoy", "Raze" };
    string[] msg = { "Você vai morrer", "Vamos lutar então!"};

    public Text nome;
    public Text fala;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nextFala()
    {
        if(stage >= msg.Length)
        {
            gameObject.SetActive(false);
            return;
        }
        fala.text = msg[stage];
        nome.text = nomeMsg[stage];
        stage++;
        return;
    }




}
