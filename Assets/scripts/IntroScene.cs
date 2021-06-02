using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroScene : MonoBehaviour
{
    bool isPause = false;
    public GameObject pause;
    private void Update() 
    {
        if(isPause) Time.timeScale = 0;
        else Time.timeScale = 1;
    }

    public void SceneChange()
    {
        Debug.Log("ASDF");
        SceneManager.LoadScene(1);
    }   

    public void ExitApplication()
    {
        Application.Quit();
    }

    public void Pause()
    {
        if (isPause) {
            Time.timeScale = 1;
            isPause = false;
            pause.GetComponent<Image>().sprite = Resources.Load<Sprite>("Play") as Sprite;
        }
        else {
            Time.timeScale = 0;
            isPause = true;
            pause.GetComponent<Image>().sprite = Resources.Load<Sprite>("Pause") as Sprite;
        }
    }
}
