using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JerarquiaTrasformacion : MonoBehaviour
{
    public Transform thisTransform;

    // Start is called before the first frame update
    void Start()
    {
        this.thisTransform = this.transform;

        Transform temp = null;

        for (int i = 0; i < this.thisTransform.childCount; i++)
        {
            temp = this.thisTransform.GetChild(i);
            Debug.Log(temp.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
