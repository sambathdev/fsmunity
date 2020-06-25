using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crash : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GoForward(2);
    }
    void GoForward(float speed){
        Vector3 pos = new Vector3(4f,1f,0);
        //sloop
        float xp = transform.position.x;
        float yp = transform.position.y;
        float xc = pos.x;
        float yc = pos.y;
        xc = xc - xp;
        yc = yc - yp;
        xp = 0;
        yp = 0;
        float a = (yp-yc)/(xp-xc);
        float b = yc-(a*xc);
        float directX = speed * 0.5f;
        float directY = a*directX + b;
        if(xc < xp){
            directX = -directX;
            directY = -directY;
        }
        
        transform.Translate( new Vector3(directX,directY,0f)*Time.deltaTime);
    }
}
