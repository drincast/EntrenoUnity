using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCETransicionesScript : MonoBehaviour
{
    public Animator animController;

    // Start is called before the first frame update
    void Start()
    {
        this.animController = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        this.Avanzar();
        this.Salto();
        this.Viento();
        this.Escala();
    }

    void Avanzar(){
        if(Input.GetButton("Fire1")){
            this.animController.SetBool("Avanzar", true);
        }

        if(Input.GetButton("Fire2")){
            this.animController.SetBool("Avanzar", false);
        }
    }

    void Salto(){
        if(Input.GetKeyDown(KeyCode.Space)){
            this.animController.SetTrigger("Salto");
        }
    }

    void Viento(){
        if(Input.GetKeyDown(KeyCode.V)){
            this.animController.SetFloat("Viento", 0.5f);
        }

        if(Input.GetKeyDown(KeyCode.B)){
            this.animController.SetFloat("Viento", 0.0f);
        }
    }

    void Escala(){
        if(Input.GetKeyDown(KeyCode.S)){
            this.animController.SetInteger("Escala", 4);
        }

        if(Input.GetKeyDown(KeyCode.D)){
            this.animController.SetInteger("Escala", 0);
        }
    }
}
