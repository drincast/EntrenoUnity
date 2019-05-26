using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Camara_ : MonoBehaviour
{
    private Text txtInfo;
    private Camera _camera;    

    private void Inicializar()
    {
        this.txtInfo = GameObject.Find("txtInfo").GetComponent<Text>();
        this._camera = this.GetComponent<Camera>();

        //if(this.txtInfo == null)
        //{
        //    Debug.Log("this.txtInfo es null");
        //}

        this.txtInfo.text = string.Format("pixelHeight: {0} - pixelWidth: {1}", this._camera.pixelHeight, this._camera.pixelWidth);
        Vector3 vec = this._camera.ScreenToWorldPoint(new Vector3(1, 2, 0));
        Rect rect = this._camera.pixelRect;
        Debug.Log(string.Format("ScreenToWorldPoint - x: {0} - y: {1} - z: {2}", vec.x, vec.y, vec.z));
        Debug.Log(string.Format("rect.x: {0} - {1} - {2}, rect.y: {3} - {4} - {5}", rect.x, rect.xMax, rect.xMin, rect.y, rect.yMax, rect.yMin));
        Debug.Log(string.Format("rect.height: {0} - rect.width: {1}, rect.max: {2} - rect.min: {3}", rect.height, rect.width, rect.max, rect.min));
        Debug.Log(string.Format("rect.center: {0}, rect.position: {1}, rect.size: {2}", rect.center.ToString(), rect.position.ToString(), rect.size.ToString()));
    }

    // Start is called before the first frame update
    void Start()
    {
        this.Inicializar();
    }
}
