using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float ElevatorSpeed, DownSpeed;

    private float EDCountdown;

    [SerializeField]
    private GameObject ControlCanvas;

    private bool EDFlag;

    [SerializeField]
    private Camera MainCamera;

    private Rigidbody CameraRigidbody;

    private float Y,YUp;

    private EDEvent eDEvent;

    private bool buttonIsDown = false;

    Stopwatch timer;

    public Text score;


    // Start is called before the first frame update
    void Start()
    {
        timer = new Stopwatch();
        eDEvent = ControlCanvas.GetComponent<EDEvent>();

        ControlCanvas.SetActive(false);

        EDCountdown = 4 * UnityEngine.Random.Range(1, 3);
      
        EDFlag = false;
        InvokeRepeating("CountDownFunction", 1f, 1f);

       

        
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + (timer.ElapsedTicks/100000);
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                ButtonIsDown();
            }
            else if(touch.phase == TouchPhase.Ended)
            {
                ButtonIsNotDown();
            }
        }

        
        if (EDCountdown<=0)
        {
            YUp = this.transform.position.y;
            EDFlag = true;
            EDEvent();

        }

        if (!EDFlag)
        {
            ControlCanvas.SetActive(false);
            if(buttonIsDown)
                this.transform.Translate(transform.up * ElevatorSpeed * Time.deltaTime);
            if(this.transform.position.y >= YUp)
            {
                MainCamera.transform.parent = this.gameObject.transform;

            }
            Y = this.transform.position.y;

        }
        else if(EDFlag)
        {
            ButtonIsNotDown();
            MainCamera.transform.parent = null;
            this.transform.Translate(transform.up * DownSpeed * Time.deltaTime * -1);

         

        }

        if (eDEvent.CorrectOrderFlag == true)
        {
            EDFlag = false;
            eDEvent.CorrectOrderFlag = false;

        }

        Death();

    }

    private void Death()
    {
        if(transform.position.y < (Y - 3f))
        {
            Destroy(this.gameObject);
        }
    }

    private void EDEvent()
    {
        ControlCanvas.SetActive(true);
        
        EDCountdown = 4 * UnityEngine.Random.Range(1, 3);  


    }

    void CountDownFunction()
    {
        if(EDFlag == false)
            EDCountdown--;
    }

    public void ButtonIsDown()
    {
        buttonIsDown = true;
        timer.Start();
    }
    public void ButtonIsNotDown()
    {
        buttonIsDown = false;
        timer.Stop();
    }


}
