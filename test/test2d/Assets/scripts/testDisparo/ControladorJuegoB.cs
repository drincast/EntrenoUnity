using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorJuegoB : MonoBehaviour
{
    private NaveB scpNave;

    public bool disparoRafaga;

    public GameObject goNaveJugador;    

    void InicializarObjetos()
    {
        this.goNaveJugador = GameObject.Find("goNaveJugador");
        this.scpNave = this.goNaveJugador.GetComponent<NaveB>();
        disparoRafaga = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        InicializarObjetos();
    }

    // Update is called once per frame
    void Update()
    {
        if(this.goNaveJugador != null)
        {
            //this.goNaveJugador.transform.Translate(Vector2.right * Input.GetAxis("Horizontal") * Time.deltaTime);
            this.scpNave.MoverNave(Input.GetAxis("Horizontal"));

            if (!this.disparoRafaga)
            {
                if (Input.GetKeyDown(KeyCode.LeftControl))
                {
                    scpNave.Disparar(this.goNaveJugador.transform.position);                
                }
            }
            else
            {
                if(Input.GetKey(KeyCode.LeftControl))
                {
                    scpNave.Disparar(this.goNaveJugador.transform.position);
                }
            }

        }
    }
}
