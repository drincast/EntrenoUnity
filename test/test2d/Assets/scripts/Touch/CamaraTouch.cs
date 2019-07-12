using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamaraTouch : MonoBehaviour
{   
    public Camera _camera;
    public float ancho;
    public float alto;

    private void Inicializar()
    {        
        this._camera = this.GetComponent<Camera>();

        //if(this.txtInfo == null)
        //{
        //    Debug.Log("this.txtInfo es null");
        //}

        Debug.Log(string.Format("----------------------- INFO GO: {0}", this.name));
        //Vector3 vec = this._camera.ScreenToWorldPoint(new Vector3(1, 2, 0));
        Rect rect = this._camera.pixelRect;
        //Debug.Log(string.Format("ScreenToWorldPoint - x: {0} - y: {1} - z: {2}", vec.x, vec.y, vec.z));
        Debug.Log(string.Format("rect.x: {0} - {1} - {2}, rect.y: {3} - {4} - {5}", rect.x, rect.xMax, rect.xMin, rect.y, rect.yMax, rect.yMin));
        Debug.Log(string.Format("rect.height: {0} - rect.width: {1}, rect.max: {2} - rect.min: {3}", rect.height, rect.width, rect.max, rect.min));
        Debug.Log(string.Format("rect.center: {0}, rect.position: {1}, rect.size: {2}", rect.center.ToString(), rect.position.ToString(), rect.size.ToString()));

        Debug.Log(string.Format("this._camera.pixelRect.xMax: {0} - this._camera.pixelRect.yMax: {1}", this._camera.pixelRect.xMax, this._camera.pixelRect.yMax));
        Debug.Log(string.Format("pixelWidth: {0} - pixelHeight: {1}", this._camera.pixelWidth, this._camera.pixelHeight));
        Debug.Log(string.Format("orthographicSize: {0} - rect.height: {1}", this._camera.orthographicSize, this._camera.transform.position.ToString()));

        this.ancho = rect.xMax;
        this.alto = rect.yMax;
    }

    // Start is called before the first frame update
    void Start()
    {
        this.Inicializar();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
