using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameText : MonoBehaviour
{
    public Transform Ball;
    public Text Nice;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Ball.position.z >= 0 && Ball.position.z < 100)
        {
            Nice.text = "Do Better";
        }else if( Ball.position.z >= 100 && Ball.position.z < 500)
        {
            Nice.text = "Good!";
        }else if( Ball.position.z >= 500 && Ball.position.z < 1000)
        {
            Nice.text = "Great!!";
        }else if( Ball.position.z >= 1500 && Ball.position.z < 3000)
        {
            Nice.text = "Unbelievable!!!";
        }else if( Ball.position.z >= 3000)
        {
            Nice.text = "Legendary!!!!";
        }
    }
}
