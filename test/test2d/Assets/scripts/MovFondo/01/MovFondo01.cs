using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovFondo01 : MonoBehaviour
{
    public bool esEjeY;
    public bool invertirMov;
    

    public bool iniciar;
    public float posicionReferencia;
    public float posicionReferenciaX;
    public float tamanioYcamara;
    public float tamanioXcamara;
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
            if(this.esEjeY){
                //el calculo del tamaño del eje y de la camara seria el yMax de la camara dividido por pixeles por unidad del sprite
                // this.tamanioYcamara = GameObject.Find("Main Camera").GetComponent<Camera>().pixelRect.yMax / this.gameObject.GetComponent<SpriteRenderer>().sprite. pixelsPerUnit;
                this.tamanioYcamara = GameObject.Find("Main Camera").GetComponent<Camera>().pixelRect.yMax / 100; //el 100 deberia ser this.gameObject.GetComponent<SpriteRenderer>().sprite.pixelsPerUnit pero da otro valor, averiguar porque                                

                //Este calculo se debe hacer con el sprite completo, el sprite debe tener la misma forma en el cuadro inicial y el final
                this.posicionReferencia = (this.GetComponent<SpriteRenderer>().size.y / 2) - (this.tamanioYcamara / 2);                

                this.ImpInfo(this.name, this.gameObject);
                Debug.Log(string.Format("this.tamanioXcamara: {0}, this.posicionReferenciaX: {1}", this.tamanioXcamara, this.posicionReferenciaX));

                this.margen = 0f;                
            }
            else{
                this.tamanioXcamara = GameObject.Find("Main Camera").GetComponent<Camera>().pixelRect.xMax / 100;
                this.posicionReferenciaX = (this.GetComponent<SpriteRenderer>().size.x / 2) - (this.tamanioXcamara / 2);
            }

            if(this.invertirMov){

            }

            res = true;
            return res;
        }
        catch (System.Exception ex)
        {
            throw ex;
        }
    }

    public bool MoverEnYHaciaAbajo(float direccion, float desplazamiento){
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
        }
        catch (System.Exception ex)
        {            
            throw ex;
        }

        return res;
    }

    public bool MoverEnYHaciaArriba(float direccion, float desplazamiento){
        bool res = false;

        try
        {
            if (this.posicionReferencia > this.transform.position.y)
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
                gameObject.transform.position = new Vector3(0, -this.posicionReferencia, 0);
            }

            res = true;    
        }
        catch (System.Exception ex)
        {            
            throw ex;
        }

        return res;
    }

    public bool MoverEnXHaciaIzquierda(float direccion, float desplazamiento){
        bool res = false;

        try
        {
            if (-this.posicionReferenciaX < this.transform.position.x)
            {
                gameObject.transform.position = new Vector3((this.transform.position.x + (direccion * desplazamiento)), 0, 0);
            }
            else
            {
                gameObject.transform.position = new Vector3(this.posicionReferenciaX, 0, 0);
            }

            res = true;    
        }
        catch (System.Exception ex)
        {            
            throw ex;
        }

        return res;
    }

    public bool MoverEnXHaciaDerecha(float direccion, float desplazamiento){
        bool res = false;

        try
        {
            Debug.Log(string.Format("direccion: {0}, desplazamiento: {1}, this.posicionReferenciaX: {2}, this.transform.position.x: {3}"
                    , direccion, desplazamiento, this.posicionReferenciaX, this.transform.position.x));
            if (this.posicionReferenciaX > this.transform.position.x)
            {
                gameObject.transform.position = new Vector3((this.transform.position.x + (direccion * desplazamiento)), 0, 0);
                //Debug.Log(string.Format("position - {0} ", gameObject.GetComponent<SpriteRenderer>().transform.position.ToString()));
            }
            else
            {
                gameObject.transform.position = new Vector3(-this.posicionReferenciaX, 0, 0);
            }

            res = true;    
        }
        catch (System.Exception ex)
        {            
            throw ex;
        }

        return res;
    }

    /*
        Desplazamiento del fondo en eje y, si this.invertirMov no esta chequeado va hacia arriba, 
        sino va hacia abajo 
        si thi
     */
    public bool MoverEnY(float desplazamiento)
    {
        bool res = false;

        try
        {
            short invertir = 1; //hacia arriba

            if(this.invertirMov){
                invertir = -1; //hacia abajo
            }

            if(invertir == 1){
                this.MoverEnYHaciaArriba(invertir, desplazamiento);
            }
            else{
                this.MoverEnYHaciaAbajo(invertir, desplazamiento);             
            }

            res = true;
            return res;
        }
        catch (System.Exception ex)
        {
            throw ex;
        }
    }

    public bool MoverEnX(float desplazamiento)
    {
        bool res = false;

        try
        {
            short invertir = 1; //hacia derecha

            if(this.invertirMov){
                invertir = -1; //hacia izquierda
            }

            if(invertir == 1){                
                this.MoverEnXHaciaDerecha(invertir, desplazamiento);
            }
            else{
                this.MoverEnXHaciaIzquierda(invertir, desplazamiento);             
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

    private void Update() {
        if(iniciar){
            if(this.esEjeY){
                this.MoverEnY(0.1f);
            }
            else{                
                this.MoverEnX(0.1f);
            } 
        }
    }
}
