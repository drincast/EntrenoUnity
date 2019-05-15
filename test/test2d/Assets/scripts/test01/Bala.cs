using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public GameObject goBala;

    public Bala(Vector3 posicion)
    {
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
        //    Debug.Log(string.Format("Error en Bala: {0}", ex));
        //    throw ex;
        //}

        return res;
    }

    public bool Desplazamiento()
    {
        bool res = false;

        this.goBala.SetActive(true);
        StartCoroutine("DesplazarBala");
        res = true;

        //try
        //{
        //    this.goBala.SetActive(true);
        //    StartCoroutine("DesplazarBala");
        //    res = true;
        //}
        //catch (System.Exception ex)
        //{
        //    Debug.Log(string.Format("Error en Bala: {0}", ex));
        //    throw ex;
        //}

        return res;
    }

    IEnumerator DesplazarBala()
    {
        float y = 0;
        yield return new WaitForSeconds(.5f);
        y = this.goBala.transform.position.y + 0.2f;
        this.goBala.transform.position = new Vector3(this.goBala.transform.position.x, y, this.goBala.transform.position.z);
    }
}
