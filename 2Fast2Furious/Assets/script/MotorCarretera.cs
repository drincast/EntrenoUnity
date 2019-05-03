using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorCarretera : MonoBehaviour
{
    public float velocidad;
    public bool inicioJuego;
    public bool finJuego;

    public GameObject goContenedorCalle;
    public GameObject[] vecContenedorCalle;

    // Start is called before the first frame update
    void Start()
    {
        this.InicioJuego();
    }

    // Update is called once per frame
    void Update()
    {
        if(this.inicioJuego && !this.finJuego){
            transform.Translate(Vector3.down * this.velocidad * Time.deltaTime);
        }        
    }

    void InicioJuego(){
        this.goContenedorCalle = GameObject.Find("ContenedorCalle");
        this.VelocidadMotorCarretera();
        BuscoCalles();
    }

    void BuscoCalles(){
        this.vecContenedorCalle = GameObject.FindGameObjectsWithTag("Calle");

        for (int i = 0; i < this.vecContenedorCalle.Length; i++)
        {
            this.vecContenedorCalle[i].gameObject.transform.parent = this.goContenedorCalle.transform;
            this.vecContenedorCalle[i].gameObject.SetActive(false);
            this.vecContenedorCalle[i].gameObject.name = string.Format("CalleOFF_" + i);
        }
    }

    void VelocidadMotorCarretera(){
        this.velocidad = 5;
    }
}
