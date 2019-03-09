using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Patrol state for Enemy.
public class PatrolState : IEnemyState
{
    private Enemy enemy;
    private float patrolTimer;
    private float patrolDuration;

    public void Enter(Enemy enemy)
    {
        patrolDuration = Random.Range(1f, 10f);
        this.enemy = enemy;
    }

    public void Execute()
    {
        Patrol();

        enemy.Move();

        if (enemy.Target != null && enemy.InMeleeRange)
        {
            enemy.ChangeState(new MeleeState());
        }
    }

    public void Exit()
    {

    }

    public void OnTriggerEnter(Collider2D other)
    {
    }

    private void Patrol()
    {
        patrolTimer += Time.deltaTime;

        if (patrolTimer >= patrolDuration)
        {
            enemy.ChangeState(new IdleState());
        }
    }
}
