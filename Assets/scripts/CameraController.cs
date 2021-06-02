using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    int _score = 0;
    public void camYPosSet(Transform aimTr)
    {
        transform.position = new Vector3(0, aimTr.transform.position.y + 2f, -10);
    }

    public void EndGame(int score){
        _score = score;
        Debug.Log(score + " " + _score);
        StartCoroutine(CamZoom());
    }

    IEnumerator CamZoom(){
        int count = 0;
        yield return null;

        while(_score*2 - Camera.main.orthographicSize > 0.5f){
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, _score * 2, Time.deltaTime);
            Debug.Log(Camera.main.orthographicSize);
            count++;
            yield return null;
        }
    }

}