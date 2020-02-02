using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioSource mainTrack1;
    public AudioSource mainTrack2;
    //public AudioSource mainBowlTrack1;
    //public AudioSource mainBowlTrack2;
    public AudioSource edTrack;
    public float totalTime;
    
    
    public void PlayMain1()
    {
        mainTrack1.PlayDelayed(0);
        mainTrack1.loop = true;
    }
    /*
    public void PlayMain2()
    {
        mainTrack2.PlayDelayed(0);
        mainTrack2.loop = true;
    }
    
    public void PlayBowlMain1()
    {
        mainBowlTrack1.PlayDelayed(0);
        mainBowlTrack1.loop = true;
    }

    public void PlayBowlMain2()
    {
        mainBowlTrack2.PlayDelayed(0);
        mainBowlTrack2.loop = true;
    }
    */
    public void PlayED()
    {
        edTrack.Play();
    }

    public void StopMain1()
    {
        mainTrack1.Stop();
    }
    /*
    public void StopMain2()
    {
        mainTrack2.Stop();
    }*/

    public void StopED()
    {
        edTrack.Stop();
    }

    private void Start()
    {
        PlayMain1();
        //Invoke("PlayMain2", 5.00f); //3.3015
    }

    private void Update()
    {
        totalTime += Time.deltaTime;
        
        //float currentDivis = Mathf.Floor(totalTime / 4.00f);
        
        if(Input.GetKeyDown("up")) //when ED happens
        {
            PlayED();
            StopMain1();
        }

        if(Input.GetKeyDown("down")) //when ED is resolved
        {
            PlayMain1();
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
