using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject daggerPrefab;
    [SerializeField] private Transform daggerSpawnPoint;
    [SerializeField] private float daggerSpeed = 0.5f;
    [SerializeField] private GameObject shootSoundObject;

    private DaggerManager daggerManager;

    public bool isTimelinePlaying = false;

    private void Awake()
    {
        daggerManager = GetComponent<DaggerManager>();
    }

    private void Update()
    {
        if (isTimelinePlaying || Time.timeScale == 0f)
        {
            return;
        }

        if (Input.GetButtonDown(GlobalStringVars.Fire_2))
        {
            ShootDagger();
            daggerManager.DecreaseDaggerCount();
        }
    }

    private void ShootDagger()
    {
        if (daggerManager.currentDaggers <= 0)
        {
            return;
        }

        GameObject dagger = Instantiate(daggerPrefab, daggerSpawnPoint.position, Quaternion.identity);

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        bool isFlipped = spriteRenderer.flipX;
        float direction = isFlipped ? -1f : 1f;

        dagger.GetComponent<Rigidbody2D>().velocity = new Vector2(direction * daggerSpeed, 0);

        _ = dagger.transform.eulerAngles;
        float rotationAngle = isFlipped ? 90f : -90f;
        Vector3 daggerRotation = new Vector3(0, 0, rotationAngle);
        dagger.transform.localEulerAngles = daggerRotation;

        if (shootSoundObject != null)
        {
            AudioSource shootSoundSource = shootSoundObject.GetComponent<AudioSource>();
            if (shootSoundSource != null)
            {
                shootSoundSource.PlayOneShot(shootSoundSource.clip);
            }
        }
    }

    public void OnTimelineEnd()
    {
        isTimelinePlaying = false;
    }
}
