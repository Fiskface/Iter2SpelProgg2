using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateMousePosition : MonoBehaviour
{
    public MousePosSO mousePosition;
    public GameObject customCursor;

    private void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition.UpdateMousePosition();
        var mp = mousePosition.mousePosition;
        customCursor.transform.position = new Vector3(mp.x, mp.y, 0);
    }
}