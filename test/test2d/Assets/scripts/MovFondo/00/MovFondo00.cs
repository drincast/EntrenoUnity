using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovFondo00 : MonoBehaviour
{
    public float tamanioYcamara;

    public bool Inicializar()
    {
        bool res = true;

        try
        {
            //el calculo del tamaño del eje y de la camara seria el yMax de la camara dividido por pixeles por unidad del sprite
            this.tamanioYcamara = GameObject.Find("Main Camera").GetComponent<Camera>().pixelRect.yMax / this.gameObject.GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;
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
            if(-this.tamanioYcamara < this.transform.position.y)
            {
                gameObject.transform.position = new Vector3(0, this.transform.position.y + (direccion * desplazamiento), 0);
                res = true;
            }
            else
            {
                gameObject.transform.position = new Vector3(0, this.tamanioYcamara, 0);
            }

            return res;
        }
        catch (System.Exception ex)
        {
            throw ex;
        }
    }

    public bool Reiniciar()
    {
        bool res = false;

        try
        {
            gameObject.transform.position = new Vector3(0, this.tamanioYcamara, 0);

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
