using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CtrlMovFondo00 : MonoBehaviour
{
    private short indiceVecFondos;

    public bool iniciar;
    public float direccionMovY;
    public float velocidadMov;
    public GameObject goFondos;

    private void Inicializar()
    {
        this.indiceVecFondos = 0;
        this.iniciar = false;
        this.direccionMovY = -1;        
        this.goFondos = GameObject.Find("Fondo");

        this.ImpInfo();
    }

    private void ImpInfo()
    {
        Debug.Log(string.Format("this.goFondos: size.x - {0}, size.y - {1} ", this.goFondos.GetComponent<SpriteRenderer>().size.x, this.goFondos.GetComponent<SpriteRenderer>().size.y));
        Debug.Log(string.Format("this.goFondos: position - {0} ", this.goFondos.GetComponent<SpriteRenderer>().transform.position.ToString()));
        Debug.Log(string.Format("pixelsPerUnit: {0} ", this.goFondos.GetComponent<SpriteRenderer>().sprite.pixelsPerUnit));
    }

    // Start is called before the first frame update
    void Start()
    {
        this.Inicializar();
    }

    // Update is called once per frame
    void Update()
    {        
        if (this.iniciar)
        {
            //Debug.Log(string.Format("this.vecGOFondos.Length: {0} - this.indiceVecFondos: {1}", this.vecGOFondos.Length, this.indiceVecFondos));
            this.goFondos.GetComponent<MovFondo00>().MoverEnY(this.direccionMovY, this.velocidadMov);
            //if (!this.vecGOFondos[this.indiceVecFondos].GetComponent<MovFondo00>().MoverEnY(this.direccionMovY, this.velocidadMov)) {                
            //    if (this.vecGOFondos.Length - 1 > this.indiceVecFondos)
            //    {
            //        this.indiceVecFondos++;
            //    }
            //    else
            //    {
            //        this.indiceVecFondos = 0;
            //    }
            //}

            //this.ImpInfo();
            //this.iniciar = false;
        }
    }
}
