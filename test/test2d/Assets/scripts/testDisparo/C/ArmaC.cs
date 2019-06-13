using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaC : MonoBehaviour
{
    public int numBalas;

    private void InicializarObjetos(){
        this.numBalas = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        this.InicializarObjetos();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool Disparar(Vector3 posicion){
        bool res = false;

        try
        {
            if(this.numBalas > 0){
                //General disparo;
                this.CrearDisparo(posicion);
                this.numBalas--;
            }
            else{
                Debug.Log(string.Format("No hay balas: {0}", "cargar arma !!!!!"));                
            }

            res = true;
            return res;
        }
        catch (System.Exception ex)
        {
            Debug.Log(string.Format("Error en ArmaC: {0}", ex.Message));
            throw ex;
        }
    }

    public bool CrearDisparo(Vector3 posicion){
        bool res = false;

        try
        {
            this.CrearBala(posicion, this.numBalas);
            res = true;
            return res;
        }
        catch (System.Exception ex)
        {
            Debug.Log(string.Format("Error en ArmaC-CrearDisparo: {0}", ex.Message));
            throw ex;
        }
    }

    public bool CrearBala(Vector3 posicion, int idBala){
        bool res = false;

        try
        {
            BalaC goBala = new BalaC(posicion, idBala);
            res = true;
            return res;
        }
        catch (System.Exception ex)
        {
            Debug.Log(string.Format("Error en ArmaC-CrearBala: {0}", ex.Message));
            throw ex;
        }
    }

}
