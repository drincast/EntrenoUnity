using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaA : MonoBehaviour
{
    public GameObject goBala;

    public BalaA(Vector3 posicion)
    {
        //TODO: usar Instantiate, otra idea es crear los go y agregarlos a la escena

        this.goBala = new GameObject("bala");
        SpriteRenderer sri = this.goBala.AddComponent<SpriteRenderer>();
        sri.sprite = Resources.Load<Sprite>("sprites/bala_14x18");
        //TODO: mejorar los numeros constantes, realizar algun tipo dede calculo para que se ajusten a cualquier tamaño
        
        this.Materializar(posicion);
    }

    private bool Materializar(Vector3 posicion)
    {
        bool res = false;

        this.goBala.SetActive(true);
        this.goBala.transform.position = new Vector3(posicion.x, posicion.y, posicion.z);
        res = true;

        //try
        //{
        //    this.goBala.SetActive(true);
        //    StartCoroutine("DesplazarBala");
        //    res = true;
        //}
        //catch (System.Exception ex)
        //{
        //    Debug.Log(string.Format("Error en BalaA: {0}", ex));
        //    throw ex;
        //}

        return res;
    }

    public bool Desplazar()
    {
        bool res = false;

        try
        {
            float y = 0;
            y = this.goBala.transform.position.y + 0.2f;
            Debug.Log(string.Format("x: {0} - y: {1} - z: {2}", this.goBala.transform.position.x, this.goBala.transform.position.y, this.goBala.transform.position.z));
            this.goBala.transform.position = new Vector3(this.goBala.transform.position.x, y, this.goBala.transform.position.z);
            Debug.Log(string.Format("x: {0} - y: {1} - z: {2}", this.goBala.transform.position.x, this.goBala.transform.position.y, this.goBala.transform.position.z));
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
            Destroy(this.goBala);
        }
        catch (System.Exception ex)
        {
            Debug.Log(string.Format("Error En BalaA - Desplazamiento: {0}", ex));
            throw;
        }

        return res;
    }
}
