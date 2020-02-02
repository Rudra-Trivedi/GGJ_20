using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioSource mainTrack;
    public AudioSource edTrack;
    public float totalTime;
    
    
    public void PlayMain()
    {
        mainTrack.Play();
        mainTrack.loop = true;
    }

    public void PlayED()
    {
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
        totalTime += Time.deltaTime;
        //float currentDivis = Mathf.Floor(totalTime / 4.00f);

        if(Input.GetKeyDown("up")) //when ED happens
        {
            PlayED();
            StopMain();
        }

        if(Input.GetKeyDown("down")) //when ED is resolved
        {
            PlayMain();
            StopED();
        }
        /*

        if(totalTime >= 4.00f)
        {
            
        }

        //if(Input.GetKeyDown("up")) //bool value for replacement
        if (totalTime >= 8.00f) //bool value for replacement
        {
            float divisibility = Mathf.Ceil(totalTime / 4);

            if(totalTime >= divisibility * 4)
            {
                StopMain();
                PlayED();
            }
            
        }*/
    }

}
