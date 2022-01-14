using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class BallMove_pz2 : MonoBehaviour
{
    public Rigidbody rb;//移动的刚体
    public Rigidbody redrb;//红色小球

    public float fallforce = -100f;//初始坠落速度
    public float forwardforce_origin = 100f;//初始前进速度
    public float forwardforce = 30f;//前进速度
    public float sideforce = 0.8f;//左右横移速度滑动系数
    public float jumpforce = 500f;//跳跃高度
    public Vector3 fristPos;//接触时的位置
    public Vector3 afterPos;//移动后的位置 
    public float moveY = 0;//前后移动的速度         
    public float moveX = 0;//左右移动的速度
    public float moveZ = 0;//上下移动的速度
    public const float JUMP_MIN_DISTANCE = 85f;//最小跳跃高度
    //public const float JUMP_MAX_DISTANCE = 120f;//最高跳跃高度
    public const float SIDE_AMP_CO = 2f;//左右横移转向系数
    public const float SIDE_CONST_FORCE = 0.06f;//左右移动最小速度
    public const float SIDE_CONST_MAX_V = 8f;//左右移动最大速度
    public const float SIDE_CONSTRAIN_FORCE = 0.13f;//左右移动约束力
    public const float GROUND_POS_Z = 0.5f;//水平高度
    public const float DEAD_POS_Y = -1f;//死亡高度
    public const float ROTATE_RATE = 5; //旋转速度
    public const float EPS = 0.001f; //在板误差
    public AnimationCurve jumpCurve;
    public Canvas endgame;//结束游戏帆布
    public Text sumtime;

    // Start is called before the first frame update
    void Start()
    {
        sumtime.text = "";
        rb.AddForce(0, fallforce, 0); //快速下落
    }
    
    private void IsDead()
    {
        //如果掉落 则返回
        if ( redrb.position.y < DEAD_POS_Y )
        {
            //Debug.Log(rb.position.y);
            //SceneManager.LoadScene("PlayGame");
            sumtime.text = "YOU'RE DEAD!";
            rb.isKinematic = true;
        }
        else if (rb.position.y < DEAD_POS_Y)
        {
            sumtime.text = "SCORE：" + Time.time.ToString("0");
            Time.timeScale = 0;
        }
    }

    private void Jump()  //跳跃函数
    {
        if (fristPos.y + JUMP_MIN_DISTANCE < afterPos.y && Camera.main.WorldToScreenPoint(transform.position).y < Screen.height)
        {

            moveZ = jumpforce * Time.deltaTime;
        }

        if (Mathf.Abs(rb.position.y - GROUND_POS_Z) < EPS)
        {
            rb.AddForce(0, moveZ, 0, ForceMode.Impulse);
        }
    }
    private void SideMoveAndFly()
    {
        moveY = 0;
        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            //获取接触屏幕的坐标 
            fristPos = Input.GetTouch(0).position;
        }
        //判断移动                 
        if (Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            //获取在屏幕上移动后的坐标 
            afterPos = Input.GetTouch(0).position;


            //判断向上移动,并且不出上方屏幕 
            if (fristPos.y < afterPos.y && Camera.main.WorldToScreenPoint(transform.position).y > 0)
            {
                if (rb.velocity.y < 0)
                {
                    moveY = SIDE_CONST_FORCE + sideforce * SIDE_AMP_CO * Time.deltaTime;
                }
                else
                {
                    moveY = SIDE_CONST_FORCE + sideforce * Time.deltaTime;
                }
            }
            //判断向下移动,并且不出下边屏幕 
            if (fristPos.y > afterPos.y && Camera.main.WorldToScreenPoint(transform.position).y > 0)
            {
                if (rb.velocity.y > 0)
                {
                    moveY = -SIDE_CONST_FORCE - sideforce * SIDE_AMP_CO * Time.deltaTime;
                }
                else
                {
                    moveY = -SIDE_CONST_FORCE - sideforce * Time.deltaTime;
                }
            }

            //判断向左移动,并且不出左边屏幕
            if (fristPos.x > afterPos.x && Camera.main.WorldToScreenPoint(transform.position).x > 0)
            {
                if (rb.velocity.x > 0)
                {
                    moveX = -SIDE_CONST_FORCE - sideforce * SIDE_AMP_CO * Time.deltaTime;
                }
                else
                {
                    moveX = -SIDE_CONST_FORCE - sideforce * Time.deltaTime;
                }
                //transform.Rotate(new Vector3(-ROTATE_RATE, 0, 0));//让球旋转
            }
            //判断向右移动,并且不出右边屏幕 
            if (fristPos.x < afterPos.x && Camera.main.WorldToScreenPoint(transform.position).x < Screen.width)
            {
                if (rb.velocity.x < 0)
                {
                    moveX = SIDE_CONST_FORCE + sideforce * SIDE_AMP_CO * Time.deltaTime;
                }
                else
                {
                    moveX = SIDE_CONST_FORCE + sideforce * Time.deltaTime;
                }
                //transform.Rotate(new Vector3(ROTATE_RATE, 0, 0));//让球旋转
            }
            //改变物体坐标 
            //transform.Translate(moveX, moveY, 0);

            //rb.AddForce(0, moveY, 0);
            if (rb.velocity.z > SIDE_CONST_MAX_V)
            {
                rb.AddForce( 0, 0, -SIDE_CONSTRAIN_FORCE, ForceMode.Impulse);
            }
            else if (rb.velocity.z < -SIDE_CONST_MAX_V)
            {
                rb.AddForce( 0, 0, SIDE_CONSTRAIN_FORCE, ForceMode.Impulse);
            }
            else
            {
                rb.AddForce( 0, 0, moveY, ForceMode.Impulse);
            }

            if (rb.velocity.x > SIDE_CONST_MAX_V)
            {
                rb.AddForce( -SIDE_CONSTRAIN_FORCE, 0, 0, ForceMode.Impulse);
            }
            else if (rb.velocity.x < -SIDE_CONST_MAX_V)
            {
                rb.AddForce( SIDE_CONSTRAIN_FORCE, 0, 0, ForceMode.Impulse);
            } else 
            {
                rb.AddForce( moveX, 0, 0, ForceMode.Impulse);
            }
        }
    }
    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        IsDead();
        SideMoveAndFly();
    }
}

