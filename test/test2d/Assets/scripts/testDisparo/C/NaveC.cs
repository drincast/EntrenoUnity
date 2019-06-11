using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveC : MonoBehaviour
{
    public ArmaC scpArmaC;

    void InicializarObjetos()
    {
        GameObject goArmaC = GameObject.Find("goArmaC");
        this.scpArmaC = goArmaC.GetComponent<ArmaC>();
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


            // int indiceDisparo = -1;

            // for (int i = 0; i < this.vecDisparos.Length; i++)
            // {
            //     if(this.vecDisparos[i] != null)
            //     {
            //         if (this.vecDisparos[i].enAccion == false)
            //         {
            //             indiceDisparo = i;
            //             this.vecDisparos[i].PosicionInicialBalas(posicion, indiceDisparo);
            //             break;
            //         }
            //     }
            // }

            // if(indiceDisparo > -1)
            //     StartCoroutine("EjecutarDisparo", this.vecDisparos[indiceDisparo]);

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

    // IEnumerator EjecutarDisparo(DisparoC disparo)
    // {
    //     for (int i = 0; i < 100; i++)
    //     {
    //         yield return new WaitForSeconds(0.1f);
    //         disparo.Desplazar();
    //         //Debug.Log(string.Format("index: {0}", i));
    //     }

    //     disparo.Finalizar();
    // }
}
