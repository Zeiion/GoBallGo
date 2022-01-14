using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform Ball;
    public Text GameScore;
    public Text Star;
    public Canvas endgame;
    public Text Nicetext;
    // Start is called before the first frame update
    void Start()
    {
        endgame.enabled = false;
        Nicetext.GetComponent<EndGameText>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(endgame.enabled == false)
        {
            GameScore.text = Ball.position.z.ToString("0");
            Star.text = Ball.GetComponent<BallCol>().count.ToString("0") + " STAR";
        }
    }
}
