using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
    public Transform anchor;         // 锚点（可拖动空物体，也可以设置为自身父物体）
    public Vector3 swingAxis = Vector3.forward; // 摆动轴（本地forward为默认）
    public float maxAngle = 60f;     // 摆动最大角度（正负）
    public float swingSpeed = 1f;    // 摆动速度（越大越快）

    private float currentAngle = 0f;

    void Update()
    {
        // 计算当前角度
        float angle = Mathf.Sin(Time.time * swingSpeed) * maxAngle;

        // 以anchor为中心、沿swingAxis旋转
        if (anchor != null)
        {
            // 绕锚点旋转
            transform.position = anchor.position + Quaternion.AngleAxis(angle, swingAxis.normalized) * Vector3.down * Vector3.Distance(anchor.position, transform.position);
            // 如果锤体有头朝下，可以加一段朝向设置
            transform.rotation = Quaternion.AngleAxis(angle, swingAxis.normalized);
        }
        else
        {
            // 以自身为锚点（自转原地摆动）
            transform.localRotation = Quaternion.AngleAxis(angle, swingAxis.normalized);
        }
    }
}
