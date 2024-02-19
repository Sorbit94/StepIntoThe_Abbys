using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private GameObject fireballPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private SpriteRenderer fireballSprite;
    [SerializeField] private float attackInterval;
    [SerializeField] private float fireballSpeed;
    [SerializeField] private AudioSource fireballAudio;

    private float currentTime;
    private bool isAttacking;
    private Vector3 targetPosition;
    private Vector2 direction;
    private bool flipX;

    private EnemyController enemyController;

    void Start()
    {
        currentTime = attackInterval;
        isAttacking = false;
        fireballSprite = fireballPrefab.GetComponent<SpriteRenderer>();

        enemyController = GetComponent<EnemyController>();
    }

    void Update()
    {
        currentTime += Time.deltaTime;

        if (CanAttack())
        {
            flipX = enemyController.GetFlipX();
            Attack(flipX);
        }

        if (isAttacking)
        {
            if (transform.position == targetPosition)
            {
                isAttacking = false;
                ResetAttackTimer();
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, fireballSpeed * Time.deltaTime);
            }
        }
    }

    public bool CanAttack()
    {
        return currentTime >= attackInterval;
    }

    public void ResetAttackTimer()
    {
        currentTime = 0;
    }

    public void Attack(bool flipX)
    {
        fireballSprite.flipX = flipX;

        direction = new Vector2(flipX ? -1 : 1, 0);

        GameObject fireball = Instantiate(fireballPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D fireballRb = fireball.GetComponent<Rigidbody2D>();

        fireballAudio.Play();

        fireballRb.velocity = direction * fireballSpeed;

        ResetAttackTimer();
    }
}
