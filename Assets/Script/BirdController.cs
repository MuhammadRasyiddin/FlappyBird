using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public static class Bird{

    public static float flyingForce  = 100f;
    public static Rigidbody2D rigidBody2;
    public static int amo = 0;
    public static int point = 0;
    public static bool isDead;
}

public class BirdController : MonoBehaviour
{
    private float coolDown = 10f;
    private float coolDownTimer = 0f;
    public GameObject bulletPrefab, popUpMenuGameOver;
    private Vector3 bulletPos;
    public  UnityEvent onFly, onDead, onGetScore;
    private  Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        ResetGame();
        Bird.rigidBody2 = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CoolDown();
        if (!Bird.isDead && Input.GetKeyDown(KeyCode.Space))
        {
            Flying();
        }
        else if(!Bird.isDead && coolDownTimer == 0 && Input.GetKeyDown(KeyCode.LeftShift))
        {
            if(Bird.amo != 0)
            {
                Shoot();
                coolDownTimer = coolDown;
            }
        }
        else if (Bird.isDead)
        {
            popUpMenuGameOver.SetActive(true);
        }
    }

    
    private float CoolDown()
    {
        return coolDownTimer>0 ? coolDownTimer -= Time.deltaTime : coolDownTimer = 0;
    }

    private void Shoot()
    {
        bulletPos = new Vector3(
            (this.transform.position.x+1f), 
            this.transform.position.y, 
            this.transform.position.z
            );
        GameObject bullet = Instantiate(bulletPrefab, bulletPos, Quaternion.identity) as GameObject;
        bullet.transform.localScale = new Vector3(0.02f, 0.02f,0);
        bullet.transform.parent = GameObject.Find("Canvas").transform;
    }

    public bool IsDead()
    {
        return Bird.isDead;
    } 
    private void Flying(){
        if(Bird.rigidBody2)
        {
            if(this.transform.position.y <= 4.5f)
            {
                Bird.rigidBody2.velocity = Vector2.zero;
                Bird.rigidBody2.AddForce(new Vector2(0, Bird.flyingForce));
            }else
            {
                Bird.rigidBody2.velocity = Vector2.zero;
                Bird.rigidBody2.AddForce(new Vector2(0, 0));
            }
        }
        if(onFly != null)
        {
            onFly.Invoke();
        }
    }
    public void Dead()
    {
        if (!Bird.isDead && onDead != null)
        {
            animator.enabled = false;
            onDead.Invoke();
        }
        Bird.isDead = true;
    } 

    public void AddScore(int value)
    {
        Bird.point += value;
        Bird.amo += value;

        if (onGetScore != null)
        {
            onGetScore.Invoke();
        }
    }

    private void ResetGame()
    {
        Bird.point = 0;
        Bird.amo = 0;
        Bird.isDead = false;
    }

}
