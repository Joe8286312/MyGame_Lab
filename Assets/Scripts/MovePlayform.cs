using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
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

        // 移动平台，顺带带动玩家
        Vector3 oldPos = transform.position;
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        Vector3 movement = transform.position - oldPos;

        // 如果有乘客，被动移动
        if (passenger != null)
        {
            passenger.position += movement;
        }

        // 判断是否到达目标
        if (Vector3.Distance(transform.position, target) < 0.01f)
        {
            isWaiting = true;
            waitTimer = waitTime;
            target = (target == endPos) ? startPos : endPos;
        }
    }

    // “带动玩家”实现：玩家进入平台成为乘客
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            passenger = collision.transform;
        }
    }

    // 玩家离开平台，不再带动
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform == passenger)
        {
            passenger = null;
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