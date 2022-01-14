using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    public const float BALL_GENERATE_DISTANCE = 200f;
    public const int START_GENERATE_TIME = 5;
    private const int g_gap = 50;
    public int origin_gap = 22;
    public List<Transform> g_originlist;
    public Transform g_start;
    public Rigidbody rb;
    public Vector3 lastEndPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(rb.position, lastEndPosition) < BALL_GENERATE_DISTANCE)
        {
            Generate();
        }
    }

    private void Awake()
    {
        //Debug.Log(g_start.position.z);
        lastEndPosition = new Vector3(g_start.position.x, g_start.position.y , g_start.position.z + g_gap + origin_gap);
        for(int i = 0; i < START_GENERATE_TIME; i++)
        {
            Generate();
        }
    }

    private void Generate()
    {
        Transform g_random = g_originlist[Random.Range(0, g_originlist.Count)];
        Transform g_last = Generate(g_random, lastEndPosition);
        lastEndPosition = new Vector3(g_last.position.x, g_last.position.y , g_last.position.z + g_gap);
    }
    private Transform Generate(Transform g_origin,Vector3 Genepos)
    {
        Transform g_newgene;
        g_newgene = Instantiate(g_origin, Genepos, Quaternion.identity);
        return g_newgene;
    }
}
