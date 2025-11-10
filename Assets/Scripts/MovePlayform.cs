using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 让平台在“当前位置”与“相对终点位置”之间往返移动
public class MovingPlatform : MonoBehaviour
{
    // 终点相对起点的偏移量。例如(2,0,0)表示向右移动2个单位
    public Vector3 endOffset = new Vector3(2, 0, 0);
    public float speed = 2f;

    private Vector3 startPos;    // 起点坐标（平台初始位置）
    private Vector3 endPos;      // 终点坐标（由startPos + endOffset得到）
    private Vector3 target;      // 当前移动目标点

    void Start()
    {
        startPos = transform.position;        // 记录起点
        endPos = startPos + endOffset;        // 通过相对值确定终点
        target = endPos;
    }

    void Update()
    {
        // 平台向目标点移动
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        // 到达目标点后换方向
        if (Vector3.Distance(transform.position, target) < 0.01f)
        {
            target = (target == endPos) ? startPos : endPos;
        }
    }

    // 在Scene视图中显示移动轨迹（辅助设计）
    void OnDrawGizmosSelected()
    {
        // 只有编辑器下有效，展示起点到终点的连线
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + endOffset);
        Gizmos.DrawSphere(transform.position + endOffset, 0.1f);
    }
}