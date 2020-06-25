using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oncollide : MonoBehaviour
{
    private float onAttack;
    private bool isAttacking = false;
    private float currentScalex = 6f;
    private float currentScaley = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isAttacking){
            onAttack += Time.deltaTime;
            GameObject[] healths;
            healths = GameObject.FindGameObjectsWithTag("health");
            
            foreach (GameObject health in healths){
                // Vector3 healthVector = health.transform.localScale;
                Vector3 decreaseHealth = new Vector3(currentScalex-onAttack,currentScaley,0f);
                health.transform.localScale = decreaseHealth;
            }
        }

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        isAttacking = true;
    }
    void OnCollisionExit2D(Collision2D collisionInfo)
    {
        isAttacking = false;
        float secOnAttack = Mathf.Round(onAttack);
        print("releasing.... has been attacked for" + secOnAttack);
        onAttack = 0f;

        GameObject[] healths;
        healths = GameObject.FindGameObjectsWithTag("health");
        foreach (GameObject health in healths){ 
            Vector3 healthVector = health.transform.localScale;
            currentScalex = healthVector.x;
        }
    }
}
