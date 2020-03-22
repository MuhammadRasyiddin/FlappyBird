using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointController : MonoBehaviour
{
    [SerializeField] private BirdController bird;
    [SerializeField] private float speed = 1;

    private void Start() 
    {
        bird = GameObject.Find("Bird").GetComponent<BirdController>();
    }
    // Update is called once per frame
    void Update()
    {
        if (!bird.IsDead())
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        BirdController bird = collision.gameObject.GetComponent<BirdController>();

        if (bird && !bird.IsDead())
        {
            bird.AddScore(1);
        }
    }
}
