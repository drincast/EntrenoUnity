using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaC : MonoBehaviour
{
    private float tamanioYcamara;    

    public float velocidad; //iniciar desde la escena el valor
    
    

    // public BalaC(Vector3 posicion, int idBala){
    //     try
    //     {
    //         //TODO: usar Instantiate, otra idea es crear los go y agregarlos a la escena
    //         this.goBala = new GameObject(string.Format("bala{0}", idBala.ToString()));
    //         SpriteRenderer sri = this.goBala.AddComponent<SpriteRenderer>();
    //         sri.sprite = Resources.Load<Sprite>("sprites/bala_14x18");

    //         this.Materializar(posicion);
    //     }
    //     catch (System.Exception ex)
    //     {
    //         Debug.Log(string.Format("Error en BalaCs: {0}", ex.Message));
    //         throw;
    //     }
    // }

    // public bool Materializar(Vector3 posicion)
    // {
    //     bool res = false;

    //     this.goBala.SetActive(true);
    //     this.goBala.transform.position = new Vector3(posicion.x, posicion.y, posicion.z);
    //     res = true;

    //     return res;
    // }

    public bool Materializar(float velocidadBala)
    {
        bool res = false;

        try
        {
            this.gameObject.SetActive(true);
            this.velocidad = velocidadBala;
            //this.goBala.transform.position = new Vector3(posicion.x, posicion.y, posicion.z);
            res = true;            
        }
        catch (System.Exception ex)
        {
            Debug.Log(string.Format("Error En BalaC - Materializar: {0}", ex));
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
            
            //this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, y, this.gameObject.transform.position.z);
            //this.gameObject.transform.Translate(Vector3.up * y * Time.deltaTime);
            this.gameObject.transform.Translate(Vector3.up * this.velocidad * Time.deltaTime);

            if(this.tamanioYcamara < this.gameObject.transform.position.y){
                Debug.Log(string.Format("this.tamanioYcamara: {0} - position.y: {1} - llamando finalizar", this.tamanioYcamara.ToString(), this.gameObject.transform.position.y.ToString()));
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
            Destroy(this.gameObject); //delay de 1 segundo
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
}
