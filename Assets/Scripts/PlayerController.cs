using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float ElevatorSpeed;

    private float EDCountdown;
    private int SequenceIndex;

    private bool EDFlag;

    private KeyCode[] KeySequence;

    // Start is called before the first frame update
    void Start()
    {
        SequenceIndex = 0;
        EDCountdown = 4 * UnityEngine.Random.Range(2, 4);
        KeySequence = new KeyCode[] { KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.UpArrow };
        EDFlag = false;
        InvokeRepeating("CountDownFunction", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {   
        if(EDCountdown<=0)
        {
            EDFlag = true;
            EDEvent();

        }

        if (!EDFlag)
        {
            this.transform.Translate(transform.up * ElevatorSpeed * Time.deltaTime);
        }
        
    }

    private void EDEvent()
    {
        if(Input.GetKeyDown(KeySequence[SequenceIndex]))
        {
            if(++SequenceIndex == KeySequence.Length)
            {
                EDFlag = false;
                EDCountdown = 4 * UnityEngine.Random.Range(2, 4);
                SequenceIndex = 0;
            }

        }

    }

    void CountDownFunction()
    {
        EDCountdown--;
    }
}
