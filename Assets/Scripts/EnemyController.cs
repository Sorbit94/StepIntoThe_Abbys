using UnityEngine;
public class EnemyController : MonoBehaviour
{
    [SerializeField] private float Speed, TimeToRevert;
    [SerializeField] private Animator anim;
    [SerializeField] private SpriteRenderer sp;

    private Rigidbody2D rb;

    private const float IdleState = 0;
    private const float WalkState = 1;
    private const float RevertState = 2;

    private float currentState, currentTimeToRevert;

    private Health health;

    private bool flipX;

    void Start()
    {
        currentState = WalkState;
        currentTimeToRevert = 0;
        rb = GetComponent<Rigidbody2D>();
        health = GetComponent<Health>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (health.GetCurrentHealth() <= 0)
        {
            rb.velocity = Vector2.zero;
            return;
        }

        if (currentTimeToRevert >= TimeToRevert)
        {
            currentTimeToRevert = 0;
            currentState = RevertState;
        }

        switch (currentState)
        {
            case IdleState:
                currentTimeToRevert += Time.deltaTime;
                break;
            case WalkState:
                rb.velocity = Vector2.right * Speed;
                break;
            case RevertState:
                flipX = !flipX;
                sp.flipX = flipX;
                Speed *= -1;
                currentState = WalkState;
                break;
        }

        if (rb.velocity.magnitude > 0.1f)
        {
            anim.SetFloat("Velosity", rb.velocity.magnitude);
        }
        else
        {
            anim.SetFloat("Velosity", 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyStopper"))
            currentState = IdleState;
    }

    public bool GetFlipX()
    {
        return flipX;
    }
}
