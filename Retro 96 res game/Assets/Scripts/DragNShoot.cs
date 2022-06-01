using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragNShoot : MonoBehaviour
{
    public float power = 10f;
    public Rigidbody2D rb;
    public Transform playerTransform;

    public Vector2 minPower;
    public Vector2 maxPower;

    Camera cam;
    Vector2 force;
    Vector3 startPoint;
    Vector3 endPoint;

    public LineRenderer lr;

    Vector3 cameraOffset = new Vector3(0, 0, 10);

    public AnimationCurve ac;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        UpdateStartPoint();

        DragIndicator();

        startPoint = playerTransform.position;

        if (Input.GetMouseButtonDown(0))
        {
            //startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            startPoint.z = 15f;
        }

        if (Input.GetMouseButtonUp(0))
        {
            endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            startPoint.z = 15f;

            force = new Vector2(Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x), Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y));
            rb.AddForce(force * power, ForceMode2D.Impulse);
        }
    }

    void DragIndicator()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lr.enabled = true;
            lr.positionCount = 2;
            //startPoint = cam.ScreenToWorldPoint(Input.mousePosition) + cameraOffset;
            //lr.SetPosition(0, startPoint);
            lr.useWorldSpace = true;
            lr.widthCurve = ac;
            lr.numCapVertices = 10;
        }
        if (Input.GetMouseButton(0))
        {
            endPoint = cam.ScreenToWorldPoint(Input.mousePosition) + cameraOffset;
            lr.SetPosition(1, endPoint);
        }
        if (Input.GetMouseButtonUp(0))
        {
            lr.enabled = false;
        }
    }

    void UpdateStartPoint()
    {
        startPoint = playerTransform.position;
        lr.SetPosition(0, startPoint);
    }
}
