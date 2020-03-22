using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 20f;
    private Rigidbody2D rigidbody2d;

    // Start is called before the first frame update
    void Start()
    { 
        rigidbody2d = GetComponent<Rigidbody2D>();
        rigidbody2d.velocity = transform.right * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag != "Indestructible" && collision.gameObject.tag != "Point")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
