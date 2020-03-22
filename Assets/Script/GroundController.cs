using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour
{
    private BirdController bird;
    private float xVelcocity = 0.1f;
    private Vector2 offset;
    private Material material;
    private void Start()
    {
        material = GetComponent<Renderer>().material;
        bird = GameObject.Find("Bird").GetComponent<BirdController>();
    }
    private void Update()
    {
        if (bird == null || (bird != null && !bird.IsDead()))
        {
            offset = new Vector2(xVelcocity, 0);
            material.mainTextureOffset += offset * Time.deltaTime;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (bird != null && !bird.IsDead())
        {
            bird.Dead();
        }
    }
}
