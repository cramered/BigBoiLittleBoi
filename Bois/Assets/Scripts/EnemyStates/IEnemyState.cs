using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Each enemy in the game must have 
// each of these functions.
public interface IEnemyState
{
    void Execute();
    void Enter(Enemy enemy);
    void Exit();
    void OnTriggerEnter(Collider2D other);
}
