using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 5f;
    public bool isFiring = false;
    Coroutine firingCoroutine;
    
    void Start()
    {
        
    }

    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (isFiring)
        {
            firingCoroutine = StartCoroutine(FireContinously());   
        }
        else
        {
            StopCoroutine(firingCoroutine);
        }
    }

    IEnumerable FireContinously()
    {
        
    }
}
