using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovFondo00 : MonoBehaviour
{
    public float posicionReferencia;
    public float tamanioYcamara;
    public float margen;

    private void ImpInfo(string nombre, GameObject go)
    {
        Debug.Log(string.Format("----------------------- INFO GO: {0}", nombre));
        Debug.Log(string.Format("size.x: {0}, size.y: {1} ", go.GetComponent<SpriteRenderer>().size.x, go.GetComponent<SpriteRenderer>().size.y));
        Debug.Log(string.Format("sprite.rect.x: {0}, sprite.rect.y: {1} ", go.GetComponent<SpriteRenderer>().sprite.rect.x, go.GetComponent<SpriteRenderer>().sprite.rect.y));
        Debug.Log(string.Format("sprite.rect.xMax: {0}, sprite.rect.yMax: {1} ", go.GetComponent<SpriteRenderer>().sprite.rect.xMax, go.GetComponent<SpriteRenderer>().sprite.rect.yMax));
        Debug.Log(string.Format("sprite.rect.width: {0}, sprite.rect.height: {1} ", go.GetComponent<SpriteRenderer>().sprite.rect.width, go.GetComponent<SpriteRenderer>().sprite.rect.height));
        Debug.Log(string.Format("position: {0} ", go.GetComponent<SpriteRenderer>().transform.position.ToString()));
        Debug.Log(string.Format("pixelsPerUnit: {0} ", go.GetComponent<SpriteRenderer>().sprite.pixelsPerUnit));
    }

    public bool Inicializar()
    {
        bool res = true;

        try
        {
            //el calculo del tamaño del eje y de la camara seria el yMax de la camara dividido por pixeles por unidad del sprite
            // this.tamanioYcamara = GameObject.Find("Main Camera").GetComponent<Camera>().pixelRect.yMax / this.gameObject.GetComponent<SpriteRenderer>().sprite. pixelsPerUnit;
            this.tamanioYcamara = GameObject.Find("Main Camera").GetComponent<Camera>().pixelRect.yMax / 100; //el 100 deberia ser this.gameObject.GetComponent<SpriteRenderer>().sprite.pixelsPerUnit pero da otro valor, averiguar porque

            this.ImpInfo(this.name, this.gameObject);

            //Este calculo se debe hacer con el sprite completo, el sprite debe tener la misma forma en el cuadro inicial y el final
            this.posicionReferencia = (this.GetComponent<SpriteRenderer>().size.y/2) - (this.tamanioYcamara / 2);
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
            //this.ImpInfo(gameObject.name, gameObject);
            //Debug.Log(string.Format("this.tamanioYcamara - {0} < this.transform.position.y - {1}", -(this.tamanioYcamara+margen), this.transform.position.y));

            //if (-(this.tamanioYcamara+(this.tamanioYcamara/2)) < this.transform.position.y)
            if (-this.posicionReferencia < this.transform.position.y)
            {
                gameObject.transform.position = new Vector3(0, (this.transform.position.y + (direccion * desplazamiento)), 0);
                //Debug.Log(string.Format("position - {0} ", gameObject.GetComponent<SpriteRenderer>().transform.position.ToString()));
            }
            else
            {
                //el calculo es aprox (el tamaño de la (spriteY/2)-(la mitad de la camara en y)
                float posIni = (this.GetComponent<SpriteRenderer>().size.y/2) - (this.tamanioYcamara/2); 
                //this.ImpInfo(gameObject.name, gameObject);                
                Debug.Log(string.Format("this.tamanioYcamara - {0}, posIni: {1}", this.tamanioYcamara, posIni));
                //gameObject.transform.position = new Vector3(0, this.tamanioYcamara, 0);
                gameObject.transform.position = new Vector3(0, this.posicionReferencia, 0);
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
