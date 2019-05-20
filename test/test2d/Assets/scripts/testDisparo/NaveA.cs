using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Disparo
{
    //public GameObject balaIzq;
    //public GameObject balaDer;

    //private Sprite CrearBala()
    //{
    //    return Resources.Load<Sprite>("sprites/bala_14x18");
    //}

    //public Disparo(Vector3 posicion)
    //{
    //    this.balaIzq = new GameObject("bala");
    //    SpriteRenderer sri = this.balaIzq.AddComponent<SpriteRenderer>();
    //    sri.sprite = CrearBala();
    //    //this.balaIzq.transform.position = new Vector3(posicion.x, posicion.y, posicion.z);
    //    //TODO: mejorar los numeros constantes, realizar algun tipo dede calculo para que se ajusten a cualquier tamaño
    //    this.balaIzq.transform.position = new Vector3(posicion.x - 0.401166f, posicion.y + 0.556f, posicion.z);

    //    this.balaDer = new GameObject("bala");
    //    SpriteRenderer srd = this.balaDer.AddComponent<SpriteRenderer>();
    //    srd.sprite = CrearBala();
    //    this.balaDer.transform.position = new Vector3(posicion.x + 0.401834f, posicion.y + 0.556f, posicion.z);

    //    this.balaIzq.SetActive(true);
    //    this.balaDer.SetActive(true);
    //}

    //public GameObject[] ObtenerDisparo()
    //{
    //    GameObject[] vec = { this.balaIzq, this.balaDer };

    //    return vec;
    //}

    public BalaA balaIzq;
    public BalaA balaDer;

    //TODO: para crear las balas, por el momento hago referencia a que se disparan dos balas, aqui ya viene el concepto de arma,
    //      esto se debe aque he tomado dos atributos de tipo bala que tienen el concepto de bala izquierda y bala derecha
    //      analizar para mejorar el código orientado a objetos, para que quede mas claro.
    private bool CrearBalas(Vector3 posicion)
    {
        bool res = false;

        try
        {
            this.balaIzq = new BalaA(new Vector3(posicion.x - 0.401166f, posicion.y + 0.556f, posicion.z));
            this.balaDer = new BalaA(new Vector3(posicion.x + 0.401834f, posicion.y + 0.556f, posicion.z));

            res = true;
        }
        catch (System.Exception ex)
        {
            Debug.Log(string.Format("Error en Nave (Disparo): {0}", ex));
            throw;
        }

        return res;
    }

    public Disparo(Vector3 posicion)
    {
        this.CrearBalas(posicion);
    }

    public void Desplazar()
    {
        try
        {
            this.balaDer.Desplazar();
            this.balaIzq.Desplazar();
        }
        catch (System.Exception ex)
        {
            Debug.Log(string.Format("Error En disparo - Desplazar: {0}", ex));
            throw;
        }
    }

    public bool Finalizar()
    {
        bool res = false;

        try
        {
            //Destroy(this.balaIzq);
            //Destroy(this.balaDer);
            this.balaIzq.FinalizarBala();
            this.balaDer.FinalizarBala();
            Debug.Log(string.Format("Destroy balas"));
            res = true;
        }
        catch (System.Exception ex)
        {
            Debug.Log(string.Format("Error en Nave (Finalizar): {0}", ex));
            throw;
        }

        return res;
    }
}

public class NaveA : MonoBehaviour
{
    //private List<GameObject[]> lstGoDisparo = null;

    //public bool MoverNave(float movimiento)
    //{
    //    bool res = false;

    //    try
    //    {
    //        this.transform.Translate(Vector2.right * movimiento * Time.deltaTime);
    //        res = true;
    //    }
    //    catch (System.Exception ex)
    //    {
    //        Debug.Log(string.Format("Error en Nave: {0}", ex));
    //        throw;
    //    }

    //    return res;
    //}

    //public bool Disparar(Vector3 posicion)
    //{
    //    bool res = false;

    //    try
    //    {
    //        this.CrearDisparo(posicion);
    //        res = true;
    //    }
    //    catch (System.Exception ex)
    //    {
    //        Debug.Log(string.Format("Error en Nave: {0}", ex));
    //        throw;
    //    }

    //    return res;
    //}

    //private List<GameObject[]> ObtenerLstGoDisparo()
    //{
    //    try
    //    {
    //        if(this.lstGoDisparo == null)
    //        {
    //            this.lstGoDisparo = new List<GameObject[]>();
    //        }
    //    }
    //    catch (System.Exception ex)
    //    {
    //        Debug.Log(string.Format("Error en Nave: {0}", ex));
    //        throw;
    //    }

    //    return this.lstGoDisparo;
    //}

    //private bool CrearDisparo(Vector3 posicion)
    //{
    //    bool res = false;
    //    Disparo disparo = null;

    //    try
    //    {
    //        disparo = new Disparo(posicion);
    //        ObtenerLstGoDisparo().Add(disparo.ObtenerDisparo());
    //    }
    //    catch (System.Exception ex)
    //    {
    //        Debug.Log(string.Format("Error en Nave: {0}", ex));
    //        throw;
    //    }

    //    return res;
    //}




    private List<Disparo> lstDisparos = null;

    public NaveA()
    {
        this.lstDisparos = new List<Disparo>();
    }

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
        Disparo tempDisparo = null;

        try
        {
            tempDisparo = this.CrearDisparo(posicion);
            //this.lstDisparos.Add(tempDisparo);

            StartCoroutine("EjecutarDisparo", tempDisparo);

            res = true;
        }
        catch (System.Exception ex)
        {
            Debug.Log(string.Format("Error en Nave - Disparar: {0}", ex));
            throw;
        }

        return res;
    }

    //private List<GameObject[]> ObtenerLstGoDisparo()
    //{
    //    try
    //    {
    //        if (this.lstGoDisparo == null)
    //        {
    //            this.lstGoDisparo = new List<GameObject[]>();
    //        }
    //    }
    //    catch (System.Exception ex)
    //    {
    //        Debug.Log(string.Format("Error en Nave: {0}", ex));
    //        throw;
    //    }

    //    return this.lstGoDisparo;
    //}

    private Disparo CrearDisparo(Vector3 posicion)
    {
        //bool res = false;
        Disparo disparo = null;

        try
        {
            disparo = new Disparo(posicion);
            //this.lstDisparo.Add(disparo);
        }
        catch (System.Exception ex)
        {
            Debug.Log(string.Format("Error en Nave: {0}", ex));
            throw;
        }

        return disparo;
    }

    IEnumerator EjecutarDisparo(Disparo disparo)
    {
        for (int i = 0; i < 49; i++)
        {
            yield return new WaitForSeconds(0.1f);
            disparo.Desplazar();
            Debug.Log(string.Format("index: {0}", i));
        }

        disparo.Finalizar();
    }
}
