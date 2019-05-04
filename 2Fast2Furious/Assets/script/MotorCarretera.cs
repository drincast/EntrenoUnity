using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorCarretera : MonoBehaviour
{
    public float velocidad;
    public bool inicioJuego;
    public bool finJuego;

    int contadorCalles = 0;
    int indiceCalles = 0;

    public GameObject goContenedorCalle;
    public GameObject[] vecContenedorCalle;

    public GameObject calleAnterior;
    public GameObject calleNueva;

    public float tamanioCalle; 


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

        CrearCalles();
    }
    
    void CrearCalles(){
        GameObject calle = null;

        this.contadorCalles ++;
        this.indiceCalles = Random.Range(0, this.vecContenedorCalle.Length);
        calle = Instantiate(this.vecContenedorCalle[this.indiceCalles]);
        calle.name = string.Format("calle{0}", this.contadorCalles); 
        calle.SetActive(true);

        // Debug.Log(string.Format("calle.transform.position", calle.transform.position.ToString()));
        // Debug.Log(string.Format("calle.transform", calle.transform));
        // Debug.Log(string.Format("calle.transform.parent", calle.transform.parent.position.ToString()));
        // Debug.Log(string.Format("gameObject.transform.position", gameObject.transform.position.ToString()));

        calle.transform.parent = gameObject.transform;
        PosicionarCalles();
    }

    void PosicionarCalles(){
        this.calleAnterior = GameObject.Find(string.Format("calle{0}", this.contadorCalles-1));
        this.calleNueva = GameObject.Find(string.Format("calle{0}", this.contadorCalles));
        MedirCalle();
        this.calleNueva.transform.position = new Vector3(this.calleAnterior.transform.position.x, 
            this.calleAnterior.transform.position.y + this.tamanioCalle - (10), 0);
    }

    void MedirCalle(){
        float tamanioPieza = 0f;
        for (int i = 0; i < this.calleAnterior.transform.childCount; i++)
        {
            if(this.calleAnterior.transform.GetChild(i).gameObject.GetComponent<FindPieza>() != null){
                tamanioPieza = this.calleAnterior.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().bounds.size.y;
                this.tamanioCalle += tamanioPieza; 
            }

        }
    }

    void VelocidadMotorCarretera(){
        this.velocidad = 5;
    }

}
