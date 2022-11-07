using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public static CameraFollow instance;
    public Transform Target;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        Vector3 newPos = new Vector3(Mathf.Lerp(transform.position.x, Target.position.x, Time.deltaTime * 3f), Mathf.Lerp(transform.position.y, Target.position.y, Time.deltaTime * 3f), -10f);

        transform.position = newPos;
    }
}
