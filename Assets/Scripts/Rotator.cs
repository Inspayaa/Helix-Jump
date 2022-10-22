using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationSpeed = 150.0f;

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.isgameStarted)
            return;


       // For Mobile
       if (Input.GetMouseButtonDown(0)/*Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved*/)
        {
            //float xDelta = Input.GetTouch(0).deltaPosition.x;
            float mouseX = Input.GetAxisRaw("Mouse X");
            transform.Rotate(/*Vector3.up */ 0, rotationSpeed * -mouseX /*xDelta */ * Time.deltaTime, 0);
        }
    }
}
