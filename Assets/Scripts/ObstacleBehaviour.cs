using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehaviour : MonoBehaviour
{
    float moveSpeed = 0f;
    void Start()
    {
        moveSpeed = GameObject.Find("Player").GetComponent<PlayerMovement>().moveSpeed;
        Destroy(gameObject, 24f * 1.5f / moveSpeed);
    }

    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
    }

}
