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
        this.goBala.transform.position = new Vector3(posicion.x, posicion.y, posicion.z);

        this.Desplazar();
    }

    public bool Desplazamiento()
    {
        bool res = false;

        try
        {
            this.goBala.SetActive(true);
            StartCoroutine("DesplazarBala");
            res = true;
        }
        catch (System.Exception ex)
        {
            Debug.Log(string.Format("Error en Bala: {0}", ex));
            throw;
        }

        return res;
    }

    IEnumerator DesplazarBala()
    {
        float y = this.goBala.transform.position.y + 0.2f;
        this.goBala.transform.position.y = y;
        yield return new WaitForSeconds(.5f);
    }
}
