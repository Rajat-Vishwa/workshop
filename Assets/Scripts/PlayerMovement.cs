using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    //public Transform transform;
    public float moveSpeed = 0;

    public float scaleFactor = 2f;
    public float scaleSpeed = 5f;

    public bool jump = false;
    public float jumpSpeed = 5f;
    public float jumpAccel = 1f;
    public float jumpTime = 0f;
    public float reactionTime = 0.5f;

    void Start()
    {
        //rb.velocity = new Vector2(moveSpeed, 0f);
        Time.timeScale = 0f;
    }

    void Update()
    {
        if(Input.GetMouseButton(0)){
            Time.timeScale = 1f;
            jump = true;
            float scale = 1f - rb.velocity.y * scaleFactor * Time.deltaTime;
            scale = Mathf.Clamp(scale, 0.6f, 1f);
            Vector3 targetScale = new Vector3(scale, scale, scale);
            transform.localScale = Vector3.Lerp(transform.localScale, targetScale, scaleSpeed * Time.deltaTime);

        }else{
            jump = false;
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one, (scaleSpeed  / 2) * Time.deltaTime);
        }
    }

    void FixedUpdate()
    {   
        if(jump){
            jumpTime += Time.fixedDeltaTime;
            float velY = Mathf.Lerp(0, jumpSpeed, jumpTime/reactionTime) + jumpAccel * jumpTime;
            rb.velocity = new Vector2(rb.velocity.x, velY  * Time.fixedDeltaTime);
        }else{
            jumpTime = 0f;
        }
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        GameObject.Find("GameManager").GetComponent<PauseManager>().GameOver();
        Destroy(gameObject);
    }
}
