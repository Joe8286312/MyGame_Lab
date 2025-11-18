using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public GameManager gameManager;

    private int star = 1;
    private void OnTriggerEnter(Collider other)
    {
        // 判断进入的是否为玩家（Tag为“Player”）
        if (other.CompareTag("Player"))
        {
            if (GameManager.Instance.CheckCollectAll())
            {
                star++;
            }
            if (GameManager.Instance.CheckDeathZero())
            {
                star++;
            }
        }
    }
}
