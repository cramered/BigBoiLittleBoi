using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Used for AI within enemies.
public class EnemySight : MonoBehaviour
{
    [SerializeField]
    private Enemy enemy;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "BigBoi" || other.tag == "LittleBoi")
        {
            enemy.Target = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "BigBoi" || other.tag == "LittleBoi")
        {
            enemy.Target = null;
        }
    }
}
