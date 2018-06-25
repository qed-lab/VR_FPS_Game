using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCountDown : MonoBehaviour {

    private CountdownManager CDM;

    public void SetCountDownNow()
    {
        CDM = GameObject.Find("321GO").GetComponent<CountdownManager>();
        CDM.countDownDone = true;

    }

}
