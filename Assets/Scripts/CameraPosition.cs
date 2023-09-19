using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    private Transform playerTransform;

    private float zValue;

    [SerializeField, Range(0, 0.01f)]private float multiplier = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
        zValue = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: Make camera movement dependentant on screen size. 
        Vector3 mousePos = Input.mousePosition;
        mousePos -= new Vector3(Screen.width / 2, Screen.height / 2, 0);
        transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, zValue) + mousePos * multiplier;
    }
}
