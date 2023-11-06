using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    public float speed;

    private Vector2 startPosition;
    private Camera cam;
    private float targetPosition;
    void Start()
    {
        cam = GetComponent<Camera>();
        targetPosition = transform.position.y;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0)) startPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        else if (Input.GetMouseButton(0))
        {
            float position = cam.ScreenToWorldPoint(Input.mousePosition).y - startPosition.y;
            targetPosition = Mathf.Clamp(transform.position.y - position, -3f, 3f);
        }
        transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, targetPosition, speed * Time.deltaTime), transform.position.z);
    }
}
