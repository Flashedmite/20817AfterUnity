using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroBox : MonoBehaviour
{
    void Update()
    {
        if(transform.position.y < -10f) gameObject.SetActive(false);
    }
}
