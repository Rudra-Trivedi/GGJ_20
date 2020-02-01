using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioSource mainTrack;
    public AudioSource edTrack;
    public bool edFlag;
    public float totalTime;
    
    public void PlayMain()
    {
        mainTrack.Play();
    }

    public void PlayED()
    {
        Debug.Log("Hello");
        edTrack.Play();
    }

    public void StopMain()
    {
        mainTrack.Stop();
    }

    public void StopED()
    {
        edTrack.Stop();
    }

    private void Start()
    {
        PlayMain();
    }

    private void Update()
    {
        if(Input.GetKeyDown("up"))
        {
            StopMain();
            PlayED();
        }
    }

}
