using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttackScript : MonoBehaviour
{
    public float bpm;
    public int damage;

    private BoxCollider2D bc;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        float moveSpeed = 60f/bpm/30f;
        InvokeRepeating("OutputTime", 0f, moveSpeed);  //1s delay, repeat every 1s
        transform.rotation = Quaternion.Euler(Vector3.forward * 90f);
    }

    void OnTriggerEnter2D(Collider2D hitObject){
        Destroy(gameObject);
        Enemy enemy = hitObject.GetComponent<Enemy>();
        enemy.health -= damage;
        Debug.Log(enemy.health);
    }

    void OutputTime() {
        transform.position = new Vector2(transform.position.x+0.5f, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
