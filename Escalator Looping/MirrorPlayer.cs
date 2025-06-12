using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform playerCamera;
    public Transform portal;
    public Transform otherPortal;
    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 playerOffset = playerCamera.position - portal.position;
        transform.position = otherPortal.position + playerOffset;

        float angleDiffPortal = Quaternion.Angle(portal.rotation,otherPortal.rotation);
        Quaternion angleDiffRotations = Quaternion.AngleAxis(angleDiffPortal,Vector3.up);
        Vector3 newCameraDirection = angleDiffRotations * playerCamera.forward;

        transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
        
    }
}
