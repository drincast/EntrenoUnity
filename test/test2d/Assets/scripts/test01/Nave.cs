using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Disparo
{
    public GameObject balaIzq;
    public GameObject balaDer;

    private Sprite CrearBala()
    {
        return Resources.Load<Sprite>("sprites/bala_14x18");
    }

    public Disparo(Vector3 posicion)
    {
        this.balaIzq = new GameObject("bala");
        SpriteRenderer sri = this.balaIzq.AddComponent<SpriteRenderer>();
        sri.sprite = CrearBala();
        //this.balaIzq.transform.position = new Vector3(posicion.x, posicion.y, posicion.z);
        //TODO: mejorar los numeros constantes, realizar algun tipo dede calculo para que se ajusten a cualquier tamaño
        this.balaIzq.transform.position = new Vector3(posicion.x - 0.401166f, posicion.y + 0.556f, posicion.z);
        
        this.balaDer = new GameObject("bala");
        SpriteRenderer srd = this.balaDer.AddComponent<SpriteRenderer>();
        srd.sprite = CrearBala();
        this.balaDer.transform.position = new Vector3(posicion.x + 0.401834f, posicion.y + 0.556f, posicion.z);

        this.balaIzq.SetActive(true);
        this.balaDer.SetActive(true);
    }

    public GameObject[] ObtenerDisparo()
    {
        GameObject[] vec = { this.balaIzq, this.balaDer };

        return vec;
    }
}

public class Nave : MonoBehaviour
{
    private List<GameObject[]> lstGoDisparo = null;

    public bool MoverNave(float movimiento)
    {
        bool res = false;

        try
        {
            this.transform.Translate(Vector2.right * movimiento * Time.deltaTime);
            res = true;
        }
        catch (System.Exception ex)
        {
            Debug.Log(string.Format("Error en Nave: {0}", ex));
            throw;
        }

        return res;
    }

    public bool Disparar(Vector3 posicion)
    {
        bool res = false;

        try
        {
            this.CrearDisparo(posicion);
            res = true;
        }
        catch (System.Exception ex)
        {
            Debug.Log(string.Format("Error en Nave: {0}", ex));
            throw;
        }

        return res;
    }

    private List<GameObject[]> ObtenerLstGoDisparo()
    {
        try
        {
            if(this.lstGoDisparo == null)
            {
                this.lstGoDisparo = new List<GameObject[]>();
            }
        }
        catch (System.Exception ex)
        {
            Debug.Log(string.Format("Error en Nave: {0}", ex));
            throw;
        }

        return this.lstGoDisparo;
    }

    private bool CrearDisparo(Vector3 posicion)
    {
        bool res = false;
        Disparo disparo = null;

        try
        {
            disparo = new Disparo(posicion);
            ObtenerLstGoDisparo().Add(disparo.ObtenerDisparo());
        }
        catch (System.Exception ex)
        {
            Debug.Log(string.Format("Error en Nave: {0}", ex));
            throw;
        }

        return res;
    }
}
