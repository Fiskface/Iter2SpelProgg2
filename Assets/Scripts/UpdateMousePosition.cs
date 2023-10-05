using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateMousePosition : MonoBehaviour
{
    public MousePosSO mousePosition;

    // Update is called once per frame
    void Update()
    {
        mousePosition.UpdateMousePosition();
    }
}
