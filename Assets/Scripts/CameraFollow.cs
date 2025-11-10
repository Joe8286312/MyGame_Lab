using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;      // 玩家球体
    public Vector3 offset = new Vector3(0, 8, -8); // 跟随偏移

    void LateUpdate()
    {
        if (target != null)
        {
            // 相机位置始终保持在目标后上方
            transform.position = target.position + offset;
            transform.LookAt(target.position);
        }
    }
}
