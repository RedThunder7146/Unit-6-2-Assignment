using UnityEngine;

public class CursorMovement : MonoBehaviour
{

    [SerializeField] Transform cam;
    public float turningSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentLookDirection = cam.forward;


        Quaternion targetRotation = Quaternion.LookRotation(currentLookDirection);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * turningSpeed);
    }
}
