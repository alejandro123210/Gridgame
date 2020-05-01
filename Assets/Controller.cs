using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public GameObject projectile;
    public GameObject releasePoint;
    public int health;
    public int bpm;
    private bool onBeat = true;
    // Start is called before the first frame update
    void Start()
    {
        float moveSpeed = 30f/bpm;
        InvokeRepeating("OutputTime", 0f, moveSpeed);  //1s delay, repeat every 1s
    }

    void OutputTime() {
        onBeat = !onBeat;
        // Debug.Log(onBeat);
    }


    //Update is called once per frame
    void Update()
    {
        if(onBeat){
            if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > -2.4){
                transform.position =  new Vector2(transform.position.x, transform.position.y-1);
            } else if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < -0.6){
                transform.position = new Vector2(transform.position.x, transform.position.y+1);
            } else if (Input.GetKeyDown(KeyCode.LeftArrow) && transform.position.x > -3.4 ){
                transform.position = new Vector2(transform.position.x-1, transform.position.y);
            } else if (Input.GetKeyDown(KeyCode.RightArrow) && transform.position.x < -0.45){
                transform.position = new Vector2(transform.position.x+1, transform.position.y);
            }

            if (Input.GetKeyDown(KeyCode.Space)){
                GameObject attack = Instantiate(projectile, releasePoint.transform.position, Quaternion.identity) as GameObject;
            }
        }
    }
}
