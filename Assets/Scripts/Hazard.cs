using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 当有物体进入触发区域时调用
    private void OnTriggerEnter(Collider other)
    {
        // 判断进入的是否为玩家（Tag为“Player”）
        if (other.CompareTag("Player"))
        {
            // 获取玩家的 PlayerController 脚本并调用重生方法
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.Respawn();
            }
        }
    }
}
