using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoC : MonoBehaviour
{
    public BalaC balaIzq;
    public BalaC balaDer;
    public bool enAccion;
    public int indice;

    public DisparoC()
    {
        this.enAccion = false;
    }

    public bool PosicionInicialBalas(Vector3 posicion, int indice)
    {
        bool res = false;

        try
        {
            this.balaIzq.Materializar(new Vector3(posicion.x - 0.401166f, posicion.y + 0.556f, posicion.z));
            this.balaDer.Materializar(new Vector3(posicion.x + 0.401834f, posicion.y + 0.556f, posicion.z));
            this.enAccion = true;
            this.indice = indice;

            res = true;
        }
        catch (System.Exception ex)
        {
            Debug.Log(string.Format("Error en Nave (Disparo): {0}", ex));
            throw;
        }

        return res;
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
            this.balaIzq.FinalizarBala();
            this.balaDer.FinalizarBala();
            this.enAccion = false;
            //Debug.Log(string.Format("Destroy balas"));
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
