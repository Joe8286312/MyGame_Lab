using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 8f;
    public float jumpForce = 8f;
    private Rigidbody rb;
    private bool isGrounded;
    private Vector3 spawnPoint; // 用于存储起始重生坐标

    public float groundCheckDistance = 0.6f; // 需要根据球体大小微调



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // 记录初始位置
        spawnPoint = transform.position;
    }

    // 重生方法
    public void Respawn()
    {
        // 将小球位置重置到初始点
        transform.position = spawnPoint;
        // 重置速度，避免保留物理惯性
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

    public Vector3 GetSpawnPoint()
    {
        return spawnPoint;
    }

    public void SetSpawnPoint(Vector3 newSpawn)
    {
        spawnPoint = newSpawn;
    }

    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(h, 0, v) * moveSpeed;

        Vector3 velocity = rb.velocity;
        rb.velocity = new Vector3(move.x, velocity.y, move.z);
    }

    void Jump()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.CompareTag("Collection"))
        //{
        //    other.gameObject.SetActive(false);
        //}
    }


}