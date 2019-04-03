using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sounds : MonoBehaviour
{
    public bool PlaySound()
    {
        bool res = false;

        GetComponent<AudioSource>().Play();

        res = true;
        return res;
    }
}
