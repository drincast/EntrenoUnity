using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaC1 : MonoBehaviour
{
    private float tamanioYcamara;
    private float velocidad; //se pasa desde el arma

    public bool Materializar(float velocidadBala)
    {
        bool res = false;

        try
        {
            this.gameObject.SetActive(true);
            this.velocidad = velocidadBala;
            res = true;            
        }
        catch (System.Exception ex)
        {
            Debug.Log(string.Format("Error En BalaC1 - Materializar: {0}", ex));
            throw;
        }

        return res;
    }

    public bool Desplazar()
    {
        bool res = false;

        try
        {
            //Debug.Log(string.Format("name: {0} - x: {1} - y: {2} - z: {3}", this.gameObject.name, this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z));
            this.gameObject.transform.Translate(Vector3.up * this.velocidad * Time.deltaTime);

            if(this.tamanioYcamara < this.gameObject.transform.position.y){
                //Debug.Log(string.Format("this.tamanioYcamara: {0} - position.y: {1} - llamando finalizar", this.tamanioYcamara.ToString(), this.gameObject.transform.position.y.ToString()));
                this.FinalizarBala();
            }

            //Debug.Log(string.Format("x: {0} - y: {1} - z: {2}", this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z));
        }
        catch (System.Exception ex)
        {
            Debug.Log(string.Format("Error En BalaA - Desplazamiento: {0}", ex));
            throw;
        }

        return res;
    }

    public bool FinalizarBala()
    {
        bool res = false;

        try
        {
            Destroy(this.gameObject);
        }
        catch (System.Exception ex)
        {
            Debug.Log(string.Format("Error En BalaC - finalizarBala: {0}", ex));
            throw;
        }

        return res;
    }

    void Start() {
        this.tamanioYcamara = GameObject.Find("Main Camera").GetComponent<Camera>().pixelRect.yMax / 100;
        Debug.Log(string.Format("start this.tamanioYcamara: {0}", this.tamanioYcamara.ToString()));
    }

    void Update() {
        try
        {
            this.Desplazar();
        }
        catch (System.Exception ex)
        {
            Debug.Log(string.Format("Error En BalaC - Update: {0}", ex));
            throw;
        }        
    }

    private void OnCollisionEnter2D(Collision2D objeto) {
        try
        {            
            if(objeto.gameObject.CompareTag("Enemigo")){
                Destroy(this.gameObject);
                //Destroy(objeto.gameObject);
                Debug.Log(string.Format("colisión con: {0}", objeto.gameObject.name));
            }
        }
        catch (System.Exception ex)
        {
            Debug.Log(string.Format("Error En BalaC - Update: {0}", ex));
            throw ex;
        }
    }
}
