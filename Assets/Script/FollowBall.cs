using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBall : MonoBehaviour
{
    public Transform Ball;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        transform.position = Ball.position + offset;
    }
}
