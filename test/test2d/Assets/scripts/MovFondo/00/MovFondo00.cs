using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovFondo00 : MonoBehaviour
{
    public float tamanioYcamara;
    public float margen;

    private void ImpInfo(string nombre, GameObject go)
    {
        Debug.Log(string.Format("{0}: size.x - {1}, size.y - {2} ", nombre, go.GetComponent<SpriteRenderer>().size.x, go.GetComponent<SpriteRenderer>().size.y));
        Debug.Log(string.Format("{0}: position - {1} ", nombre, go.GetComponent<SpriteRenderer>().transform.position.ToString()));
        Debug.Log(string.Format("pixelsPerUnit: {0} ", go.GetComponent<SpriteRenderer>().sprite.pixelsPerUnit));
    }

    public bool Inicializar()
    {
        bool res = true;

        try
        {
            //el calculo del tamaño del eje y de la camara seria el yMax de la camara dividido por pixeles por unidad del sprite
            this.tamanioYcamara = GameObject.Find("Main Camera").GetComponent<Camera>().pixelRect.yMax / this.gameObject.GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;
            this.margen = 0f;
            res = true;
            return res;
        }
        catch (System.Exception ex)
        {
            throw ex;
        }
    }

    public bool MoverEnY(float direccion, float desplazamiento)
    {
        bool res = false;

        try
        {
            //Debug.Log(string.Format("this.tamanioYcamara - {0} < this.transform.position.y - {1}", -(this.tamanioYcamara+margen), this.transform.position.y));
            if (-(this.tamanioYcamara+margen) < this.transform.position.y)
            {
                gameObject.transform.position = new Vector3(0, this.transform.position.y + (direccion * desplazamiento), 0);
                //Debug.Log(string.Format("position - {0} ", gameObject.GetComponent<SpriteRenderer>().transform.position.ToString()));
            }
            else
            {
                this.ImpInfo(gameObject.name, gameObject);
                //el calculo es aprox (el tamaño de la (spriteY/2)-(la mitad de la camara en y)
                Debug.Log(string.Format("this.tamanioYcamara - {0}", this.tamanioYcamara));
                gameObject.transform.position = new Vector3(0, this.tamanioYcamara, 0);
            }

            res = true;
            return res;
        }
        catch (System.Exception ex)
        {
            throw ex;
        }
    }

    private void Start()
    {
        this.Inicializar();
    }
}
