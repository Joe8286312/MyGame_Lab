using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationRateX = 0f;
    public float rotationRateY = 100f;
    public float rotationRateZ = 0f;

    void Update()
    {
        transform.Rotate(new Vector3(rotationRateX, rotationRateY, rotationRateZ) * Time.deltaTime);
    }
}
