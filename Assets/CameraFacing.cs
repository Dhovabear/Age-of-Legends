using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFacing : MonoBehaviour
{
    // Start is called before the first frame update

    private void LateUpdate()
    {
        transform.LookAt(GameObject.Find("PlayerCamera").transform.position);
    }
}
