
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Transform CameraAxisTransform;

    public float RotationSpeed;
    public float minAngle;
    public float maxAngle;

    void Update()
    {
        RotationY();
        RotationX();
    }



    void RotationY()
    {
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y + Time.deltaTime * RotationSpeed * Input.GetAxis("Mouse X"), 0);


    }
    void RotationX()
    { 
        var newAngleX = CameraAxisTransform.localEulerAngles.x - Time.deltaTime * RotationSpeed * Input.GetAxis("Mouse Y");
        if (newAngleX > 180)
            newAngleX -= 360;
        newAngleX = Mathf.Clamp(newAngleX, minAngle, maxAngle);
        
        CameraAxisTransform.localEulerAngles = new Vector3(newAngleX, 0, 0);
    }
}
