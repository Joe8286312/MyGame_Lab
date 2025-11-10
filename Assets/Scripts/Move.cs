using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Vector3 endOffset = new Vector3(2, 0, 0);  // 相对当前位置的终点偏移
    public float speed = 2f;                           // 平台移动速度
    public float waitTime = 1.5f;                      // 停留时间（秒）

    private Vector3 startPos;
    private Vector3 endPos;
    private Vector3 target;
    private float waitTimer = 0f;
    private bool isWaiting = false;
    private Transform passenger = null;

    void Start()
    {
        startPos = transform.position;
        endPos = startPos + endOffset;
        target = endPos;
    }

    void Update()
    {
        if (isWaiting)
        {
            waitTimer -= Time.deltaTime;
            if (waitTimer <= 0f)
                isWaiting = false;
            else
                return;
        }

        Vector3 lastPos = transform.position;
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        // 向PlatformPassenger通知运动量
        var passenger = GetComponent<Passenger>();
        if (passenger != null)
            passenger.OnPlatformMoved(transform.position - lastPos);

        if (Vector3.Distance(transform.position, target) < 0.01f)
        {
            isWaiting = true;
            waitTimer = waitTime;
            target = (target == endPos) ? startPos : endPos;
        }
    }

    // Gizmos辅助：显示路径
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + endOffset);
        Gizmos.DrawSphere(transform.position + endOffset, 0.1f);
    }
}