using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveC1 : MonoBehaviour
{
    public ArmaC1 scpArmaC;

    void InicializarObjetos()
    {
        GameObject goArmaC = GameObject.Find("goArmaC");
        this.scpArmaC = goArmaC.GetComponent<ArmaC1>();
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

        try
        {
            this.scpArmaC.Disparar(posicion);
            res = true;
        }
        catch (System.Exception ex)
        {
            Debug.Log(string.Format("Error en Nave - Disparar: {0}", ex));
            throw ex;
        }

        return res;
    }

    private void Start() {
        this.InicializarObjetos();
    }
}
