using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float speed;
    public GameObject pipeUp, pipeDown;

    void Start()
    {
        HoleController();
    }

    void Update()
    {
        this.gameObject.transform.Translate(new Vector2(-speed * Time.deltaTime, 0));

        //destroy
        if (this.gameObject.transform.localPosition.x < -8.5f)
        {
            Destroy(this.gameObject);
        }
    }

    private void HoleController()
    {
        float randomPos;
        randomPos = Random.Range(0f, 0.3f);
        pipeUp.transform.localPosition = new Vector2(0, pipeUp.transform.localPosition.y + randomPos);
        pipeDown.transform.localPosition = new Vector2(0, pipeDown.transform.localPosition.y - randomPos);
    }
}
