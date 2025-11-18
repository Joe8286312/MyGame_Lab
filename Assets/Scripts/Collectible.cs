using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [Header("Effects")]
    public AudioClip collectSound;
    public GameObject collectEffect;
    public float destroyDelay = 0.2f;

    private bool isCollected = false;

    private void OnTriggerEnter(Collider other)
    {
        if (isCollected) return;

        if (other.CompareTag("Player"))
        {
            isCollected = true;

            // 1. 播放音效
            if (collectSound)
            {
                AudioSource.PlayClipAtPoint(collectSound, transform.position);
            }

            // 2. 播放特效
            if (collectEffect)
            {
                Instantiate(collectEffect, transform.position, Quaternion.identity);
            }

            // 3. 通知游戏管理器
            GameManager.Instance.AddCollect();

            // 4. 隐藏或销毁对象（延迟销毁可见粒子效果）
            gameObject.SetActive(false);
            Destroy(gameObject, destroyDelay);
        }
    }
}
