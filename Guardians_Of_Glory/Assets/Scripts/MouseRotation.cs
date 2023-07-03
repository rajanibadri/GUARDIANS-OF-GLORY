using System.Collections;
using System.Collections.Generic;
using UnityEngine;


   

public class MouseRotation : MonoBehaviour
{
    public Transform objectToRotate;
    public float rotationSpeed = 10f;

    private void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector3 direction = mousePosition - objectToRotate.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.Euler(0, 0, angle);
        objectToRotate.rotation = Quaternion.Slerp(objectToRotate.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
}


