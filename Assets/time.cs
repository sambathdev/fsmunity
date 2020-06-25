using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class time : MonoBehaviour
{
    float timeStart = 0;
    float timeIndirection = 0;
    // Start is called before the first frame update
    void Start()
    {
        AddComponent();
        
    }

    // Update is called once per frame
    void Update()
    {
        setDirection();
        GoForward(2f);
    
    }

    void setDirection(){
        timeIndirection += Time.deltaTime;
        float tid = Mathf.Round(timeIndirection);
        if(tid == 3){
            print("yoyo 3 sec");
            timeIndirection = 0;
        }
    }
    void moveObject(){

    }
    void GoForward(float speed){
        Vector3 pos = new Vector3(2f,2f,0);
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

    float starttime(){
        timeStart += Time.deltaTime;
        return Mathf.Round(timeStart);
    }
    void AddComponent(){
        Rigidbody2D rigid = gameObject.AddComponent<Rigidbody2D> ();
        gameObject.AddComponent<CircleCollider2D> ();
        rigid.gravityScale = 0f;
    }
}
