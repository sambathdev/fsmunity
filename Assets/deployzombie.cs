using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deployzombie : MonoBehaviour
{
    public GameObject zombiePrefab;
    public float respawnTime = 5.0f;
    private Vector2 screenBounds;
    private bool isGameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(zombieWave());
    }

    private void spawnEnemy(){
        GameObject a = Instantiate(zombiePrefab) as GameObject;
        float dx = Random.Range(-11.0f, 11.0f);
        float dy = Random.Range(-5.0f, 5.0f);
        a.transform.position = new Vector2(dx, dy);
    }

    IEnumerator zombieWave(){
        while(true){
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();
        }
    } 
    // Update is called once per frame
    void Update()
    {
        
        if(isGameOver == true){
            print("game over");
        }
        GameObject[] healths;
        healths = GameObject.FindGameObjectsWithTag("health");
        
        foreach (GameObject health in healths){
            Vector3 healthVector = health.transform.localScale;
            if(healthVector.x <= 0){
                isGameOver = true;
            }
        }
    }
}
