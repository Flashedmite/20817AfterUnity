using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] boxPrefab;

    //UI
    public Text scoreText;
    private int score;
    public GameObject retryButton;

    private void Start()
    {
        score = 0;
        retryButton.SetActive(false);
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
        Instantiate(boxPrefab[Random.Range(0,5)], GenPos, boxPrefab[0].transform.rotation);
    }

    public void GameOver()
    {
        retryButton.SetActive(true);
    }

    // UI
    private void scorePlus()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}