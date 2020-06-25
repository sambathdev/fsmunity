using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addcolidandrigit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AddComponent();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void AddComponent(){
        gameObject.AddComponent<Rigidbody2D> ();
        gameObject.AddComponent<CircleCollider2D> ();
    }
}
