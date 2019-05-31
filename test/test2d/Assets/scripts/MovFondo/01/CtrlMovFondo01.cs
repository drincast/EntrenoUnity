using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * La idea de este ejemplo es probar el movimiento mas basico, contar con un sprite de fondo grande, ponerlo a moverse en una dirección llegar a una determinada
 * posición y reiniciar la posición.
 * 
 * Funciona pero se debe tener cuidado con el diseño del sprite del fondo ya que debe tener una simetria en las posiciones de inicio y fin donde
 * ocurre el reinicio de la posición.
 * 
 * uno de los objetivos es: solo debe existir una función update que debe ir en una clase que controle todo.
 */

public class CtrlMovFondo01 : MonoBehaviour
{
    private short indiceVecFondos;

    public bool iniciar;
    public float direccionMovY;
    public float velocidadMov;
    public GameObject goFondos;
    public string nombreFondo;

    public DatosJuego refDatosJuegos;

    private void Inicializar()
    {
        this.indiceVecFondos = 0;
        this.iniciar = false;
        this.direccionMovY = -1;

        refDatosJuegos = DatosJuego.Instancia;

        if (!nombreFondo.Equals(""))
        {
            this.goFondos = GameObject.Find(this.nombreFondo);
        }        

        this.ImpInfo();
    }

    private void ImpInfo()
    {
        Debug.Log(string.Format("----------------------- INFO GO: {0}", this.name));
        Debug.Log(string.Format("this.goFondos: size.x - {0}, size.y - {1} ", this.goFondos.GetComponent<SpriteRenderer>().size.x, this.goFondos.GetComponent<SpriteRenderer>().size.y));
        Debug.Log(string.Format("this.goFondos: position - {0} ", this.goFondos.GetComponent<SpriteRenderer>().transform.position.ToString()));
        Debug.Log(string.Format("pixelsPerUnit: {0} ", this.goFondos.GetComponent<SpriteRenderer>().sprite.pixelsPerUnit));
    }

    void Start()
    {
        this.Inicializar();
    }

    void Update()
    {        
        if (this.iniciar)
        {
            //Debug.Log(string.Format("this.vecGOFondos.Length: {0} - this.indiceVecFondos: {1}", this.vecGOFondos.Length, this.indiceVecFondos));
            //this.goFondos.GetComponent<MovFondo01>().MoverEnY(this.direccionMovY, (this.velocidadMov));
            //this.ImpInfo();
        }
    }
}

public class DatosJuego
{
    private static DatosJuego instancia;

    public bool iniciar;
    public int direccion;
    public float velocidad;

    private DatosJuego(){
        this.iniciar = false;
        this.direccion = -1;
        this.velocidad = 0.1f;
    }

    public static DatosJuego Instancia
    {
        get
        {
            if(instancia == null){
                instancia = new DatosJuego();
            }
            return instancia;
        }
    }
}
