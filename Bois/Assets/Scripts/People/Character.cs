using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Blueprint for all characters in game.
public abstract class Character : MonoBehaviour
{
    [SerializeField]
    protected float movementSpeed = 0;

    protected bool facingRight;

    [SerializeField]
    protected int lives;

    [SerializeField]
    private List<string> damageSources;

    public abstract bool IsDead { get; }

    public bool Attack { get; set; }

    public Animator MyAnimator { get; private set; }

    // Start is called before the first frame update
    public virtual void Start()
    {
        facingRight = true;
        MyAnimator = GetComponent<Animator>();
    }


    public abstract IEnumerator Hit();

    public void ChangeDirection()
    {
        facingRight = !facingRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, 1, 1);
    }


    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (damageSources.Contains(other.tag))
        {
            StartCoroutine(Hit());
        }
    }
}
