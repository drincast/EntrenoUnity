using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovAdam : MonoBehaviour
{
    public Animator anim;
    public float ejeVertical;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        this.ejeVertical = Input.GetAxis("Vertical");
        anim.SetFloat("caminar", this.ejeVertical);
        anim.SetFloat("caminarAtras", this.ejeVertical);
    }
}
