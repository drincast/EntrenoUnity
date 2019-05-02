using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereColliderSC : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(string.Format("entrando en {0}", collision.gameObject.name));
    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log(string.Format("dentro de {0}", collision.gameObject.name));
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log(string.Format("saliendo de {0}", collision.gameObject.name));        
    }
}
