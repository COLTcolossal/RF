using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSwap : MonoBehaviour
{
    private BGmusic track;
    public AudioClip newTrack;
    public GameObject Boss1;

    void Start()
    {
        track = FindObjectOfType<BGmusic>();

        if (Boss1.activeInHierarchy == true)
        {
            track.SwapTrack(newTrack);
            
        }

    }

   
    void Update()
    {
       



    }
}
