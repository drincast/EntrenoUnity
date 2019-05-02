using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Componente : MonoBehaviour
{
    public Transform transformCamara;
    private BoxCollider boxColliderMe;
    // Start is called before the first frame update
    void Start()
    {
        boxColliderMe = GetComponent<BoxCollider>();

        Debug.Log("---- Info Componentes -----");
        Debug.Log("component: " + transformCamara.GetType().Name);
        Debug.Log("name: " + transformCamara.name);
        Debug.Log("propiedad position: " + transformCamara.position.ToString());
        Debug.Log("----  -----");        
        Debug.Log("component: " + boxColliderMe.GetType().Name);
        Debug.Log("name: " + boxColliderMe.name);
        Debug.Log("propiedad enable: " + boxColliderMe.enabled);
        Debug.Log("propiedad inactivando propiedad enable: ");
        boxColliderMe.enabled = false;
        Debug.Log("----  -----");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
