using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaC1 : MonoBehaviour
{
    public float balaMargenPosicionY; //margen de posicionamiento en eje y, para posicionar mejor el inicio de la bala segun el GO de donde sale
    
    public GameObject bala; //para instanciar el tipo de bala que usara el arma, instancias desde la escena
    public int numBalas;  //el número máximo de balas, si es -1 son infinitas
    public float velocidadBala;

    private void InicializarObjetos(){
        if(this.bala != null){
            this.bala.SetActive(false);
        }
        else{
            Debug.LogError("No se ha establecido el game objec bala", this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        this.InicializarObjetos();
    }

    // Update is called once per frame
    // void Update()
    // {
        
    // }

    public bool Disparar(Vector3 posicion){
        bool res = false;

        try
        {
            Vector3 nuevaPosicion = (this.balaMargenPosicionY != 0 ? new Vector3(posicion.x, posicion.y + this.balaMargenPosicionY, posicion.z) : posicion);

            if(this.numBalas == -1){
                this.CrearDisparo(nuevaPosicion);
            }
            else
            {
                if(this.numBalas > 0){
                    this.CrearDisparo(nuevaPosicion);
                    this.numBalas--;
                }
                else{
                    Debug.Log(string.Format("No hay balas: {0}", "cargar arma !!!!!"));                
                }                
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
            GameObject goBala = Instantiate(this.bala, posicion, Quaternion.identity);
            goBala.name = string.Format("goBala{0}", idBala.ToString());
            BalaC1 scpBala = goBala.GetComponent<BalaC1>();
            scpBala.Materializar(this.velocidadBala);
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
