using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform mainCamera;
    public Transform lensCamera;

    // Update is called once per frame
    void Update()
    {
        Vector3 localPlayer = lensCamera.InverseTransformPoint(mainCamera.position);
        transform.position = lensCamera.position;

        Vector3 lookatmirror = lensCamera.TransformPoint(new Vector3(-localPlayer.x, -localPlayer.y, -localPlayer.z));
        transform.LookAt(lookatmirror, lensCamera.up);
    }
}
