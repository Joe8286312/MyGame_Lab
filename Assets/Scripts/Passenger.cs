using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passenger : MonoBehaviour
{

    private Transform passenger = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

    // 平台每帧运动时调用
    public void OnPlatformMoved(Vector3 movement)
    {
        if (passenger != null)
        {
            passenger.position += movement;
        }
    }
}
