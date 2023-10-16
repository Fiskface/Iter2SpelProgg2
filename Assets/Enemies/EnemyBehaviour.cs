using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private TargetBehaviour target;

    private void Awake()
    {
        target = GetComponent<TargetBehaviour>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        target.hit += OnHit;
    }

    private void OnDisable()
    {
        target.hit -= OnHit;
    }

    private void OnHit(int damage)
    {
        
    }
}
