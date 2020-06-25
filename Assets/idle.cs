using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idle : MonoBehaviour
{
    private float timeIndirection = 0;
    private float dx = 0f;
    private float dy = 0f;
    private Vector3 direct = new Vector3(1f,1f,0);
    // Start is called before the first frame update
    void Start()
    {
        AddComponent();

    }

    // Update is called once per frame
    void Update()
    {
        changedirection(5f);
        GoForward(2);
    }
    void changedirection(float secs){
        timeIndirection += Time.deltaTime;
        float tid = Mathf.Round(timeIndirection);
        if(tid == secs){
            print("changed direction");
            dx = Random.Range(-11.0f, 11.0f);
            dy = Random.Range(-5.0f, 5.0f);
            timeIndirection = 0;
        }
    }
    void GoForward(float speed){
        Vector3 pos = new Vector3(dx,dy,0);
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
        if(float.IsInfinity(a)){
            if(yp>yc){
                directY = -speed * 0.5f;
            }else{
                directY = speed * 0.5f;
            }
            
            directX = 0;
        }
        if(xc < xp){
            directX = -directX;
            directY = -directY;
        }
        
        transform.Translate( new Vector3(directX,directY,0f)*Time.deltaTime);
    }
    void AddComponent(){
        Rigidbody2D rigid = gameObject.AddComponent<Rigidbody2D> ();
        BoxCollider2D collide = gameObject.AddComponent<BoxCollider2D> ();
        rigid.gravityScale = 0f;
        collide.size = new Vector2(3.6f, 6.8f);
        // collide.y = 6.8f;
    }
    
}
