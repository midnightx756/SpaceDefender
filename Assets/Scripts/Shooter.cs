using System.Collections;
using UnityEngine;
using System.Collections.Generic;
//using Unity.Mathematics;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 5f;
    [SerializeField] float MinimumRate = 0.2f;

    [Header("AI")]
    [SerializeField] float firingRate = 2f;
    [SerializeField] float firingRateVariance = 0f;
    [SerializeField] bool useAI;

    [HideInInspector]public bool isFiring;

    Coroutine firingCoroutine;

    AudioPlayer audioPlayer;

    void Awake()
    {
        audioPlayer = FindFirstObjectByType<AudioPlayer>();
    } 
    void Start()
    {
        if (useAI)
        {
            isFiring = true;
        }
        firingCoroutine = null;
    }

    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (isFiring && firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(FireContinously());
        }
        else if (!isFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    
    }

    IEnumerator FireContinously()
    {
        while (true)
        {
            GameObject instance = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = transform.up * projectileSpeed;
            }
            Destroy(instance, projectileLifetime);
            audioPlayer.PlayShootingCLip();
            yield return new WaitForSecondsRealtime(1 / GetRandomFireRate());
        }
    }

    float GetRandomFireRate()
    {
        float fire = Random.Range(firingRate - firingRateVariance, firingRate + firingRateVariance);
        return Mathf.Clamp(fire, MinimumRate, float.MaxValue);
    }
}
