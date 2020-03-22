using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{

    public float xVelcocity;
    private Vector2 offset;
    public MeshRenderer material;

    void Update()
    {
        offset = new Vector2(xVelcocity, 0);
        material.material.mainTextureOffset += offset * Time.deltaTime;
    }
}
