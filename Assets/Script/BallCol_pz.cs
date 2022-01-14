using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallCol_pz : MonoBehaviour
{
    public BallMove_pz movement;
    public Canvas endgame;
    public Text Deadtext;
    public float count;
    public AudioSource ding;
    // Start is called before the first frame update
    void Start()
    {
        count = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle") //撞到障碍物，结束游戏
        {
            movement.enabled = false;
            endgame.enabled = true;
            Deadtext.text = "YOU'RE DEAD!";
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Star")  //吃掉星星
        {
            ding.Play();
            Destroy(collision.gameObject);
            count++;
        }
    }
}
