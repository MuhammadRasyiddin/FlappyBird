using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    // Start is called before the first frame update
    private BirdController bird;
    private float speed = 1;
    public GameObject pipe;
    void Start()
    {
        bird = GameObject.Find("Bird").GetComponent<BirdController>();
    }

    private void Update()
    {
        if (this.gameObject.activeInHierarchy == false)
        {
            Destroy(this.gameObject);
        }
        if (!bird.IsDead())
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (bird)
        {
            Collider2D collider = GetComponent<Collider2D>();
            if (collider)
            {
                collider.enabled = false;
            }
            bird.Dead();
        }
    }

}
