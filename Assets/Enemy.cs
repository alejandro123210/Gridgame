using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float bpm;
    public int health;
    private bool attack = false;
    // Start is called before the first frame update
    void Start()
    {  
        float moveSpeed = 60f/bpm;
        InvokeRepeating("OutputTime", 0f, moveSpeed);  //1s delay, repeat every 1s
    }

    void OutputTime() {
        if(attack){
            Debug.Log("attack");
            attack = false;
        } else {
            attack = true;
            System.Random rnd = new System.Random();
            int moveDirecton = rnd.Next(3);
            // int moveDirecton = 3;
            if (moveDirecton == 0 && transform.position.y > -2.4){
                transform.position =  new Vector2(transform.position.x, transform.position.y-1);
            } else if (moveDirecton == 1 && transform.position.y < -0.6){
                transform.position = new Vector2(transform.position.x, transform.position.y+1);
            } else if (moveDirecton == 2 && transform.position.x > 1.4 ){
                transform.position = new Vector2(transform.position.x-1, transform.position.y);
            } else if (moveDirecton == 3 && transform.position.x < 3.4){
                transform.position = new Vector2(transform.position.x+1, transform.position.y);
            } 
        } 
    } 

    // Update is called once per frame
    void Update()
    {
        if(health <= 0){
            Destroy(gameObject);
        }
    }
}
