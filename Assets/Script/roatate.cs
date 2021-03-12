using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roatate : MonoBehaviour
{
    Touch touch;
    Vector2 touchpos;
    Quaternion roatationY;
   
    float rotatespeed = 0.1f;
    bool abc = true;
    private void Update()
    {
        if (Input.touchCount>0)
        {
            touch = Input.GetTouch(0);
            if(touch.phase==TouchPhase.Moved)
            {
                roatationY = Quaternion.Euler(0f, -touch.deltaPosition.x* rotatespeed, 0f);
                transform.rotation = roatationY*transform.rotation;
            }
        }
        if (Input.touchCount > 1)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            { 
                transform.localScale = transform.localScale + new Vector3(2.0f, 2.0f, 2.0f);
            }
        }
    }

   
}
