using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchMovPlayer : MonoBehaviour
{
    private Text txtTexto;
    public float velocidad;


    // Start is called before the first frame update
    void Start()
    {
        this.txtTexto = GameObject.Find("txtTexto").GetComponent<Text>();
        this.velocidad = 1;
    }

    // Update is called once per frame
    void Update()
    {
        float direccion = Input.GetAxis("Horizontal");
        this.transform.Translate(Vector2.right * (this.velocidad*direccion) * Time.deltaTime);

        //for (var touch : Touch in Input.touches) {
        foreach (Touch touch in Input.touches)
        {
            this.txtTexto.text = string.Format("fingerId: {0} - position: {1} - deltaPosition: {2} - deltaTime: {3} - tapCount: {4} - phase: {5}", 
                touch.fingerId, touch.position, touch.deltaPosition, touch.deltaTime, touch.tapCount, touch.phase);
        }
        // for (touch : Touch in Input.touches) {
        //     // if (touch.phase == TouchPhase.Began) {
        //     //     // Construct a ray from the current touch coordinates
        //     //     var ray = Camera.main.ScreenPointToRay (touch.position);

        //     //     if (Physics.Raycast (ray)) {
        //     //         // Create a particle if hit
        //     //         Instantiate (particle, transform.position, transform.rotation);
        //     //     }
        //     // }
        // }
    }
}
