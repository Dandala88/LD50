using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform follow;
    [SerializeField]
    private Vector3 offset;

    private void LateUpdate()
    {
        float x = Mathf.Cos((Vector3.SignedAngle(follow.forward, Vector3.forward, Vector3.up) - 90) * Mathf.Deg2Rad) * offset.magnitude;
        float z = Mathf.Sin((Vector3.SignedAngle(follow.forward, Vector3.forward, Vector3.up) - 90) * Mathf.Deg2Rad) * offset.magnitude;
        Vector3 offsetCalc = new Vector3(x, offset.y, z);
        transform.position = follow.position + offsetCalc;
        transform.LookAt(follow.position);
    }
}
