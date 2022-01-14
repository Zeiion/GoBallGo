using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    
    public class Music : MonoBehaviour
{
    public AudioSource music;
    void Awake()
    {
        if (music != this)
        {
            DontDestroyOnLoad(music);
        }
    }
}
