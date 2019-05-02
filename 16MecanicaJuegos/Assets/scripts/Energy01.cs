using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy01 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
