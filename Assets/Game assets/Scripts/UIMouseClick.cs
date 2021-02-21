using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMouseClick : MonoBehaviour
{
    public RectTransform movingObject;
    public Vector3 offset;
    public RectTransform basisObject;
    public Camera cam;
 

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveObject()
    {
        Vector3 pos = Input.mousePosition + offset;
        pos.z = basisObject.position.z;
        movingObject.position = cam.ScreenToWorldPoint(pos);
    }
}
