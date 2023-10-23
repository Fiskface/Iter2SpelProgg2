using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyDrops : MonoBehaviour
{
    public List<GameObject> drops;

    public void Drop()
    {
        if (Random.Range(1, 2) == 1)
        {
            Instantiate(drops[Random.Range(0, drops.Count - 1)],
                gameObject.transform.position, Quaternion.identity);
        }
    }
}
