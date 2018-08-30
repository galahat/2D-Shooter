using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    float speed = 1, bulletSpeed = 20;

    Rigidbody2D rb;

    [SerializeField]
    GameObject bullet;

    public static Player myPlayer;

	// Use this for initialization
	void Start () {
        myPlayer = this;
        rb = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate () {

        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity += Vector2.left * speed * Time.fixedDeltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity += Vector2.right * speed * Time.fixedDeltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity += Vector2.down * speed * Time.fixedDeltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity += Vector2.up * speed * Time.fixedDeltaTime;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.up = (Vector2)(mousePos - (Vector2)transform.position).normalized;
    }

    void Shoot()
    {
        GameObject myBullet = Instantiate(bullet,transform.position,transform.rotation);
        myBullet.GetComponent<Rigidbody2D>().velocity += (Vector2)transform.up.normalized * bulletSpeed;
        Destroy(myBullet, 20);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);

        }
    }
}
