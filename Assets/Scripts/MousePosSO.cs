using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MousePosition", menuName = "ScriptableObjects/MousePosition")]
public class MousePosSO : ScriptableObject
{
    public Camera mainCamera;
    public Vector3 mousePosition { get; private set; } = Vector3.zero;

    private void OnEnable()
    {
        mainCamera = Camera.main;
    }

    public void UpdateMousePosition()
    {
        mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
    }
}
