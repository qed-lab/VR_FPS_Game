using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class testcurve : MonoBehaviour
{

    public Vector3 yourDestinationVector3;
    public float yourTimeFloat;
    public GameObject yourObject;

    void Update()
    {
        yourObject.transform.DOMove(yourDestinationVector3, yourTimeFloat).SetLoops(-1, LoopType.Yoyo);
    }
}