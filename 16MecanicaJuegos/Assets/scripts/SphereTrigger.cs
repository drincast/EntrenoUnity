using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(string.Format("Entrando a {0}", other.name));
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log(string.Format("Dentro de {0}", other.name));
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log(string.Format("Salio de {0}", other.name));
    }
}
