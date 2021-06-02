using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] boxPrefab;
    private GameObject nowBox;

    public Text scoreText; //UI
    private int score;
    private bool isTouched;

    private void Start()
    {
        score = 0;

        Camera.main.transform.position -= Vector3.up * 2.5f;
        GenerateBox();
        Camera.main.GetComponent<CameraController>().camYPosSet(nowBox.transform);
    }

    private void Update() {
        Touch();
    }

    public void Touch(){
        if (!Input.GetMouseButtonDown(0) || isTouched || EventSystem.current.IsPointerOverGameObject()) return;
        nowBox.GetComponent<Rigidbody2D>().gravityScale = 1;
        StartCoroutine(nowBox.GetComponent<BoxControl>().CheckLanded());

        isTouched = true;
        nowBox.GetComponent<BoxControl>().isTouched = isTouched;
    }

    // 착지 성공시 해당 블럭에서 이 코드 부름
    public void Landed(Transform aimTr)
    {
        Camera.main.GetComponent<CameraController>().camYPosSet(aimTr);
        Invoke("GenerateBox", 0.1f);
        scorePlus();
    }


    /// 실제 메소드
    /// /////////////////////////////////////////////////////////////
    /// 실제 메소드

    public void GenerateBox()
    {
        Vector3 GenPos = new Vector3(Random.Range(-2f,2f), Camera.main.transform.position.y + 2.5f, 0);
        nowBox = Instantiate(boxPrefab[Random.Range(0,5)], GenPos, boxPrefab[0].transform.rotation);

        
        isTouched = false;
        nowBox.GetComponent<BoxControl>().isTouched = isTouched;
    }

    public void GameOver()
    {
        print("끝");
        Camera.main.GetComponent<CameraController>().EndGame(score);
    }

    // Score UI
    public void scorePlus()
    {
        score++;
        scoreText.text = score.ToString();
    }
}