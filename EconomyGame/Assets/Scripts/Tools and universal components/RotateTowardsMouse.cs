using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsMouse : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        UpdateRotation();
    }

    private void UpdateRotation()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);

        if (screenPos.x > Input.mousePosition.x)
        {
            Quaternion rotation = Quaternion.Euler(0, 180, 0);
            transform.localRotation = rotation;
        }
        else
        {
            Quaternion rotation = Quaternion.Euler(0, 0, 0);
            transform.localRotation = rotation;
        }
    }
}
