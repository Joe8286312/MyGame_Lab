using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float yOffset = 1f; // 重生点与平台的垂直距离（上方偏移）

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                Vector3 newSpawn = transform.position + Vector3.up * yOffset;
                // 仅在新重生点与玩家当前不同才设置
                if (Vector3.Distance(player.GetSpawnPoint(), newSpawn) > 0.1f)
                {
                    player.SetSpawnPoint(newSpawn);
                }
            }
        }
    }
}
