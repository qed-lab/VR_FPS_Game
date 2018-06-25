using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCrosshair : MonoBehaviour
{

    private Vector3 startPos;
    //private transform newPos;
    public Camera cameraFacing;
    public GameObject crosshair;
    private Vector3 originalScale;
    private Quaternion Rotation;
    float deadzone = 0.25f;
    private float oldValuex = 0f;
    private float oldValuey = 0f;




    // Use this for initialization
    void Start()
    {
        //crosshair.transform.position = cameraFacing.transform.position +
        // cameraFacing.transform.rotation * Vector3.forward ;
        originalScale = crosshair.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {

        float hAxis = Input.GetAxisRaw("AimJoystickHorizontal");
        float vAxis = Input.GetAxisRaw("AimJoystickVertical");


        
        if (Mathf.Abs(hAxis) > 0.01f || Mathf.Abs(vAxis) > 0.01f)
        {
            if (Mathf.Abs(hAxis) < Mathf.Abs(oldValuex))
            {
                oldValuex = hAxis;
                return;
            }

            if (Mathf.Abs(vAxis) < Mathf.Abs(oldValuey))
            {
                oldValuey = vAxis;
                return;
            }

            oldValuex = hAxis;
            oldValuey = vAxis;

            Vector2 stickInput = new Vector2(vAxis * 30, hAxis * 30);
            if (stickInput.magnitude < deadzone)
                stickInput = Vector2.zero;
            else
                stickInput = stickInput.normalized * ((stickInput.magnitude - deadzone) / (1 - deadzone));

            Rotation = Quaternion.Euler(stickInput.x, stickInput.y, 0);

            RaycastHit hit;
            float distance;

            if (Physics.Raycast(new Ray(cameraFacing.transform.position,
                                        cameraFacing.transform.rotation * Rotation * Vector3.forward),
                                        out hit))
            {
                distance = hit.distance;
            }
            else
            {
                distance = cameraFacing.farClipPlane * 0.95f;
            }

           crosshair.transform.position = cameraFacing.transform.position + 
                cameraFacing.transform.rotation * Rotation * Vector3.forward * distance;


            // Debug.Log(distance);

            crosshair.transform.LookAt(cameraFacing.transform.position);
            crosshair.transform.Rotate(0.0f, 180.0f, 0.0f);
            crosshair.transform.localScale = originalScale * distance;

        }
    }
}
