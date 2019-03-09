using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision : MonoBehaviour
{
    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;

    private void Update()
    {
        Physics2D.IgnoreCollision(player1.GetComponent<BoxCollider2D>(), player2.GetComponent<BoxCollider2D>(), true);
    }
}