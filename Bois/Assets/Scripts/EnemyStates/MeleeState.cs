using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Melee state for Enemy.
public class MeleeState : IEnemyState
{
    [SerializeField]
    private float attackTimer;

    [SerializeField]
    private float attackCoolDown;
    private bool canAttack = true;

    private Enemy enemy;
     
    public void Enter(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public void Execute()
    {
        Attack(); 
        if(enemy.Target == null)
        {
            enemy.ChangeState(new IdleState());
        }
    }

    public void Exit()
    {
       
    }

    public void OnTriggerEnter(Collider2D other)
    {

    }

    private void Attack()
    {
        attackTimer += Time.deltaTime;

        if (attackTimer >= attackCoolDown)
        {
            canAttack = true;
            attackTimer = 0;
        }

        if (canAttack)
        {
            canAttack = false;
            enemy.MyAnimator.SetTrigger("attack");
        }
    }
}
