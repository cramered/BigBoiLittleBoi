using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Enemies will hurt bigBoi or littleBoi
public class Enemy : Character
{
    private IEnemyState currentState;

    [SerializeField]
    private GameObject armor;

    public GameObject Target { get; set; }

    [SerializeField]
    private float meleeRange;

    [SerializeField]
    private Transform leftEdge;

    [SerializeField]
    private Transform rightEdge;

    private float boxColliderSizeY;

    [SerializeField]
    private EdgeCollider2D FistCollider;

    private bool ChangedCollider = false;

    public override void Start()
    {
        base.Start();
        movementSpeed = Random.Range(1f, 7f);
        ChangeState(new IdleState());
        boxColliderSizeY = gameObject.GetComponent<BoxCollider2D>().size.y;
    }

    void Update()
    {
        if (!IsDead)
        {
            currentState.Execute();

            LookAtTarget();
        }

    }

    private void LookAtTarget()
    {
        if (Target != null)
        {
            float xDir = Target.transform.position.x - transform.position.x;

            if (xDir < 0 && facingRight || xDir > 0 && !facingRight)
            {
                ChangeDirection();
            }
        }
    }

    public void ChangeState(IEnemyState newState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }
        currentState = newState;

        currentState.Enter(this);
    }


    public void Move()
    {

        if ((GetDirection().x > 0 && transform.position.x < rightEdge.position.x) || (GetDirection().x < 0 && transform.position.x > leftEdge.position.x))
        {
            MyAnimator.SetFloat("speed", 1);

            transform.Translate(GetDirection() * (movementSpeed * Time.deltaTime));
        }
        else if(currentState is PatrolState){
            ChangeDirection();
        }
    }

    public Vector2 GetDirection()
    {
        if (facingRight)
        {
            return Vector2.right;
        }
        else
        {
            return Vector2.left;
        }
    }

    public void MeleeAttack()
    {
        FistCollider.enabled = !FistCollider.enabled;
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        currentState.OnTriggerEnter(other);
    }

    public bool InMeleeRange
    {
        get
        {
            if (Target != null)
            {
                return Vector2.Distance(transform.position, Target.transform.position) <= meleeRange;
            }

            return false;
        }
    }

    public override IEnumerator Hit()
     {
        lives -= 1;
        if (lives == 1)
        {
            Destroy(armor);
        }
        if (!IsDead)
        {
            MyAnimator.SetTrigger("damage");
        }
        else
        {
            MyAnimator.SetTrigger("die");
            if (ChangedCollider == false)
            {
                ChangedCollider = true;
                gameObject.GetComponent<BoxCollider2D>().size -= new Vector2(0, (.5f * boxColliderSizeY));
            }
            StartCoroutine(KillSprite());
            yield return new WaitForSeconds(1f);
        }
    }


    public override bool IsDead
    {
        get
        {
            return lives <= 0;
        }
    }

    private IEnumerator KillSprite()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
