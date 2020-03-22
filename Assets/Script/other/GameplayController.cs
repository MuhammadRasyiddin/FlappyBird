using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviour
{
    public GameObject pipes;

    void Start()
    {
        StartCoroutine(SpawnPipe());
    }

    private IEnumerator SpawnPipe()
    {
        while (true)
        {
            yield return new WaitForSeconds(4);
            float randomPos;
            randomPos = Random.Range(-0.5f,3.5f);

            GameObject obj = Instantiate(pipes, new Vector2(7.75f, 0), Quaternion.identity);
            obj.transform.localPosition = new Vector2(obj.transform.localPosition.x, obj.transform.localPosition.y + randomPos);
        }
    }
}
