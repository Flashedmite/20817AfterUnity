using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public void camYPosSet(Transform aimTr)
    {
        transform.position = new Vector3(0, aimTr.transform.position.y + 2f, -10);
    }

}