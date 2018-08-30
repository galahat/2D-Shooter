using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField]
    float speed = 1;

    [SerializeField]
    GameObject FX;

    Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.up = (transform.position - Player.myPlayer.transform.position).normalized;
        rb.velocity -= (Vector2)transform.up * speed * Time.deltaTime;
        
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);

            GameObject myFX = Instantiate(FX, transform.position, transform.rotation);
            Destroy(myFX,10);
        }
    }
}
