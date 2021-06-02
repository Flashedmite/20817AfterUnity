using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BoxControl : MonoBehaviour
{
    
    private float moveSpeed;
    private int moveDirect;
    public bool isTouched = false;

    private Rigidbody2D rb;
    private GameManager gameManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        rb.gravityScale = 0;
        moveSpeed = 4f;
        moveDirect = 1;
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if(isTouched) return;
        if (transform.position.x > 3.5f) moveDirect = -1;
        if (transform.position.x < -3.5f) moveDirect = 1;
        transform.Translate(Vector2.right * moveDirect * moveSpeed * Time.deltaTime);
    }


    // 터치하면 실행되는 착지 여부 확인 메소드
    public IEnumerator CheckLanded()
    {
        int checkAttemped = 0;
        int checkLanded = 0;

        while (checkAttemped++ < 25)
        {
            Debug.Log($"Att : {checkAttemped}, Land = {checkLanded}");
            if (Mathf.Abs(rb.velocity.y) <= 0.02f)
            {
                checkLanded++;
                if (checkLanded > 3) break;
            }
            yield return new WaitForSeconds(0.2f);
        }

        if (checkLanded > 3) gameManager.Landed(transform);
        else gameManager.GameOver();

        StopCoroutine(CheckLanded());
    }
}
