using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    private Camera mainCamera;
    private Vector3 target, mousePos, refVel, shakeOffset, shakeVector, shakeRandomVector;
    private float cameraDist = 2f, smoothTime = 0.1f, zStart, shakeMag, shakeTimeEnd;
    private bool shaking;

    void Start()
    {
        target = player.position;
        zStart = transform.position.z;
        mainCamera = Camera.main;
    }

    void Update()
    {
        mousePos = CaptureMousePos();
        shakeOffset = UpdateShake();
        target = UpdateTargetPos();
        UpdateCameraPosition();
    }

    private Vector3 CaptureMousePos()
    {
        Vector2 ret = mainCamera.ScreenToViewportPoint(Input.mousePosition);
        ret *= 2;
        ret -= Vector2.one;

        ret = new Vector2(Mathf.Clamp(ret.x, -1, 1),
            Mathf.Clamp(ret.y, -1, 1));

        return ret;
    }

    private Vector3 UpdateTargetPos()
    {
        Vector3 mouseoffset = mousePos * cameraDist;
        Vector3 ret = player.position + mouseoffset;
        ret += shakeOffset;
        ret.z = zStart;
        return ret;
    }

    void UpdateCameraPosition()
    {
        Vector3 tempPos;
        tempPos = Vector3.SmoothDamp(transform.position, target, ref refVel, smoothTime);
        transform.position = tempPos;
    }

    public void Shake(Vector3 direction, float magnitude, float length)
    {
        shaking = true;
        shakeVector = direction;
        shakeRandomVector = Random.Range(-0.3f, 0.3f) * magnitude * 
                            new Vector3(direction.y, -direction.x, direction.z);
        shakeMag = magnitude;
        shakeTimeEnd = Time.time + length;
    }

    Vector3 UpdateShake()
    {
        if (!shaking || Time.time > shakeTimeEnd)
        {
            shaking = false;
            return Vector3.zero;
        }

        Vector3 tempOffset = shakeVector;
        tempOffset += shakeRandomVector;
        tempOffset *= shakeMag;
        return tempOffset;
    }
}
