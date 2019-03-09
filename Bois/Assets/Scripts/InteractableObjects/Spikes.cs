using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Spikes will kill either of the players.
public class Spikes : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("LittleBoi"))
        { 
            col.gameObject.GetComponent<SmallGuyController>().Hit();
        }
        if (col.gameObject.CompareTag("BigBoi"))
        {
            col.gameObject.GetComponent<LargeGuyController>().Hit();
        }
    }
}
