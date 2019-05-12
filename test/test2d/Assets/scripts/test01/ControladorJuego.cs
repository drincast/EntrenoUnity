using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorJuego : MonoBehaviour
{
    public GameObject goNaveJugador;    

    void InicializarObjetos()
    {
        this.goNaveJugador = GameObject.Find("goNaveJugador");
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
            Nave scpNave = this.goNaveJugador.GetComponent<Nave>();
            //this.goNaveJugador.transform.Translate(Vector2.right * Input.GetAxis("Horizontal") * Time.deltaTime);
            scpNave.MoverNave(Input.GetAxis("Horizontal"));

            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                scpNave.Disparar(this.goNaveJugador.transform.position);
            }
        }
    }
}
