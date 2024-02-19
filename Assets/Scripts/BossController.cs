using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField] private GameObject fireBall;
    [SerializeField] private Transform player;
    [SerializeField] private float fireBallSpeed = 5f;

    private List<GameObject> fireBalls = new List<GameObject>();

    [SerializeField] private AudioSource soundSource;

    private void Start()
    {
        StartBossFight();
    }

    public void StartBossFight()
    {
        StartCoroutine(ThrowFireBalls());
    }

    private void Update()
    {
        if (player == null)
            return;

        for (int i = fireBalls.Count - 1; i >= 0; i--)
        {
            GameObject fireBall = fireBalls[i];

            if (fireBall == null)
            {
                fireBalls.RemoveAt(i);
                continue;
            }

            Vector3 direction = (player.position - fireBall.transform.position).normalized;
            fireBall.transform.position += direction * fireBallSpeed * Time.deltaTime;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            fireBall.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }

    private Vector3 GetCameraBounds()
    {
        float screenZ = -Camera.main.transform.position.z;
        Vector3 topLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, screenZ));
        Vector3 topRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, screenZ));

        return new Vector3(topLeft.x, topLeft.y, topRight.x);
    }

    private IEnumerator ThrowFireBalls()
    {
        Vector3 cameraBounds = GetCameraBounds();

        while (true)
        {
            GameObject leftFireBall = Instantiate(fireBall, new Vector3(cameraBounds.x, cameraBounds.y, 0f), Quaternion.identity);
            fireBalls.Add(leftFireBall);

            soundSource.Play();

            Destroy(leftFireBall, 5f);

            GameObject rightFireBall = Instantiate(fireBall, new Vector3(cameraBounds.z, cameraBounds.y, 0f), Quaternion.identity);
            fireBalls.Add(rightFireBall);

            soundSource.Play();

            Destroy(rightFireBall, 5f);

            yield return new WaitForSeconds(4f);
        }
    }

}



