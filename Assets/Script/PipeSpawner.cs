using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private BirdController bird;
    private float holeSize;
    private float maxMinOffset = 1;
    public GameObject[] pipes, pipes_;
    private GameObject clone;
    private float holes;
    private float posUp, posUp_;
    private float posDown, posDown_;
    private float posHole;
    // Start is called before the first frame update

    void Start()
    {
        StartCoroutine(SpawnPipes());
    }

    private void Update()
    {
        for(int i = 0; i<pipes.Length; i++)
        {
            if(pipes[i] == null)
            {
                pipes[i] = pipes_[i];
            }
        }
    }

    IEnumerator SpawnPipes()
    {
        yield return new WaitForSeconds(Random.Range(2f, 5f));
        holeSize = Random.Range(1f, 2f);
        for(int i = 0; i < pipes.Length; i++)
        {
            clone = (GameObject)Instantiate(pipes[i], transform.position, Quaternion.identity);
            pipes[i] = clone;
            clone.transform.localScale = new Vector3(2f, 2f,0);
            clone.transform.parent = GameObject.Find("PipeSpawner").transform;
            if(clone.tag == "PipeUp")
            {
                holes  = transform.position.y+1f * (holeSize / 2);
                float y = maxMinOffset * Mathf.Sin(Time.time);
                posUp += transform.position.y+1f * y;
                posUp_ = holes + posUp;
                clone.transform.position = new Vector3(transform.position.x, posUp_, transform.position.z);
            }
            else if(clone.tag == "PipeDown")
            {
                holes  = transform.position.y-1f * (holeSize / 2);
                float y = maxMinOffset * Mathf.Sin(Time.time);
                posDown += transform.position.y+1f * y;
                posDown_ = holes + posDown;
                clone.transform.position = new Vector3(transform.position.x, posDown_, transform.position.z);
            }
            else
            {
                float y = maxMinOffset * Mathf.Sin(Time.time);
                posHole += transform.position.y+1f * y;
                clone.transform.localScale = new Vector3(holeSize, holeSize*800f,0);
                clone.transform.position = new Vector3(transform.position.x, posHole, transform.position.z);
            }
        }   
        if(!Bird.isDead)
        {
            StartCoroutine(SpawnPipes());
        }
        else
        {
            StopCoroutine(SpawnPipes());
        }
    }
}
