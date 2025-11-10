using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingObstacle : MonoBehaviour
{
    public float rotationRateX = 0f;
    public float rotationRateY = 100f;
    public float rotationRateZ = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(rotationRateX, rotationRateY, rotationRateZ) * Time.deltaTime);
    }
}
