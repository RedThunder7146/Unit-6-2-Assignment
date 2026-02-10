using JetBrains.Annotations;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform cam;
    public Movementscript movementScript;
    public Vector3 moveDir;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;


    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3(movementScript.turnInput, 0f , movementScript.moveInput).normalized;

        if (direction.magnitude>= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        }
        


    }
}
