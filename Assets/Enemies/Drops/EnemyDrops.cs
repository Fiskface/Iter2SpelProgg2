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
            var random = Random.Range(0, drops.Count - 1);
            Instantiate(drops[random],
                gameObject.transform.position, drops[random].transform.rotation);
        }
    }
}
