using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EDEvent : MonoBehaviour
{

    public Queue<int> symbolsQueue;
    public int[] symbolsArray;

    public bool CorrectOrderFlag;

    public RawImage image1;
    public RawImage image2;
    public RawImage image3;

    public GameObject button1;
    public GameObject button2;
    public GameObject button3;

    public Texture2D icon1;
    public Texture2D icon2;
    public Texture2D icon3;
    public Texture2D icon4;
    public Texture2D icon5;
    public Texture2D icon6;
    public Texture2D arrow_down;
    public Texture2D arrow_up;
    public Texture2D arrow_left;
    public Texture2D arrow_right;

    Dictionary<int, Texture2D> icons;

    void Start()
    {
        CorrectOrderFlag = false;
        SwipeDetector.OnSwipe += SwipeDetector_OnSwipe;
        symbolsQueue = new Queue<int>();
        icons = new Dictionary<int, Texture2D>();
        icons.Add(1, icon1);
        icons.Add(2, icon2);
        icons.Add(3, icon3);
        icons.Add(4, icon4);
        icons.Add(5, icon5);
        icons.Add(6, icon6);
        icons.Add(7, arrow_down);
        icons.Add(8, arrow_up);
        icons.Add(9, arrow_left);
        icons.Add(10, arrow_right);
        fillQueue();
    }

    void Update()
    {
            
    }

    public void buttonClick(int num)
    {
        if (num == symbolsQueue.Peek())
        {
            symbolsQueue.Dequeue();
            symbolsArray = symbolsQueue.ToArray();
            if(symbolsArray.Length > 2)
            {
                image1.texture = icons[symbolsArray[0]];
                image2.texture = icons[symbolsArray[1]];
                image3.texture = icons[symbolsArray[2]];
            }
            else if(symbolsArray.Length == 2)
            {
                image1.texture = icons[symbolsArray[0]];
                image2.texture = icons[symbolsArray[1]];
                button3.SetActive(false);
            }
            else if(symbolsArray.Length == 1)
            {
                image1.texture = icons[symbolsArray[0]];
                button2.SetActive(false);
                button3.SetActive(false);
            }
            else
            {
                Debug.Log("correct order");
                CorrectOrderFlag = true;
                fillQueue();
            }
        }

        else
        {
            CorrectOrderFlag = false;
            symbolsQueue.Clear();
            Debug.Log("wrong order");
            fillQueue();
            
        }
            
    }

    void fillQueue()
    {
        for(int i = 0; i < 6; i++)
        {
            symbolsQueue.Enqueue(Random.Range(1, 11));
            
        }

        symbolsArray = symbolsQueue.ToArray();
        button1.SetActive(true);
        button2.SetActive(true);
        button3.SetActive(true);
        image1.texture = icons[symbolsArray[0]];
        image2.texture = icons[symbolsArray[1]];
        image3.texture = icons[symbolsArray[2]];

    }

    private void SwipeDetector_OnSwipe(SwipeData data)
    {
        int num = 7;
        if (data.Direction == SwipeDirection.East)
            num = 10;
        else if (data.Direction == SwipeDirection.West)
            num = 9;
        else if (data.Direction == SwipeDirection.North)
            num = 8;
        buttonClick(num);
    }

}
