using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // 判断进入的是否为玩家（Tag为“Player”）
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.ResetInfo();
        }

    }
}
