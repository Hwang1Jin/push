using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Example_DoTween_CameraShake : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DOTween.Init();
    }

    public void ShakeCamera()
    {
        transform.DOShakePosition(0.5f,1, 10, 90, true).OnComplete<Tween>(SetOriginPosition);
    }

    void SetOriginPosition()
    {
        transform.SetLocalPositionAndRotation(new Vector3(0, 1, -10), Quaternion.Euler(0, 0, 0));
    }
}
