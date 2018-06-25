using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveloop2D : MonoBehaviour
{



    public AnimationCurve myCurve2;

    void Update()
    {
        //transform.position = new Vector3(transform.position.x, myCurve2.Evaluate((Time.time % myCurve2.length)), transform.position.z);
        transform.localPosition = new Vector3(myCurve2.Evaluate((Time.time % myCurve2.length)), myCurve2.Evaluate((Time.time % myCurve2.length)), transform.localPosition.z);
    }
}
