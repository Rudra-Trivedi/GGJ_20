using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject background;

    [SerializeField]
    private GameObject UpperPivot;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            background.transform.position = UpperPivot.transform.position;
        }
    }
    
        
    
}
