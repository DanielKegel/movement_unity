using UnityEngine;
using System.Collections;

// Script by IJM: http://answers.unity3d.com/questions/29741/mouse-look-script.html
// Changed to fit standard C# conventions

// MouseLook rotates the transform based on the mouse delta.
// Minimum and Maximum values can be used to constrain the possible rotation

// To make an FPS style character:
// - Create a capsule.
// - Add a rigid body to the capsule
// - Add the MouseLook script to the capsule.
// -> Set the mouse look to use LookX. (You want to only turn character but not tilt it)
// - Add FPSWalker script to the capsule

/// - Create a camera. Make the camera a child of the capsule. Reset it's transform.
/// - Add a MouseLook script to the camera.
/// -> Set the mouse look to use LookY. (You want the camera to tilt up and down like a head. The character already turns.)
[AddComponentMenu("Camera-Control/Mouse Look")]
public class MouseLook : MonoBehaviour
{

    public enum RotationAxes { MouseZAndY = 0, MouseZ = 1, MouseY = 2 };
    public RotationAxes axes = RotationAxes.MouseZAndY;
    public float sensitivityZ = 15F;
    public float sensitivityY = 15F;

    public float minimumZ = -360F;
    public float maximumZ = 360F;

    public float minimumY = -60F;
    public float maximumY = 60F;

    float rotationZ = 0F;
    float rotationY = 0F;

    Quaternion originalRotation;

    void Update()
    {
        if (axes == RotationAxes.MouseZAndY)
        {
            // Read the mouse input axis
            rotationZ += Input.GetAxis("Mouse Z") * sensitivityZ;
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;

            rotationZ = ClampAngle(rotationZ, minimumZ, maximumZ);
            rotationY = ClampAngle(rotationY, minimumY, maximumY);

            Quaternion zQuaternion = Quaternion.AngleAxis(rotationZ, Vector3.up);
            Quaternion yQuaternion = Quaternion.AngleAxis(rotationY, -Vector3.right);

            transform.localRotation = originalRotation * zQuaternion * yQuaternion;
        }
        else if (axes == RotationAxes.MouseZ)
        {
            rotationZ += Input.GetAxis("Mouse Z") * sensitivityZ;
            rotationZ = ClampAngle(rotationZ, minimumZ, maximumZ);

            Quaternion zQuaternion = Quaternion.AngleAxis(rotationZ, Vector3.up);
            transform.localRotation = originalRotation * zQuaternion;
        }
        else
        {
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = ClampAngle(rotationY, minimumY, maximumY);

            Quaternion yQuaternion = Quaternion.AngleAxis(-rotationY, Vector3.right);
            transform.localRotation = originalRotation * yQuaternion;
        }
    }

    void Start()
    {
        // Make the rigid body not change rotation
        if (GetComponent<Rigidbody>())
            GetComponent<Rigidbody>().freezeRotation = true;
        originalRotation = transform.localRotation;
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }
}