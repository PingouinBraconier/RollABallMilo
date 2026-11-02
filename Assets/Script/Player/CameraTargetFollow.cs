using UnityEngine;

public class CameraTargetFollow : MonoBehaviour
{
    
    [SerializeField] public Transform Player;
    [SerializeField] public float Height = 1f;
    [SerializeField] public float MouseSensitivity = 2f;
    [SerializeField] public float minVerticalAngle = -30f;
    [SerializeField] public float maxVerticalAngle = 70f;

    private float yaw;
    private float pitch;

    private void Start()
    {
        Vector3 angles = transform.eulerAngles;

        yaw = angles.y;
        pitch = angles.x;

        if (pitch > 180f)
            pitch -= 360f;
        LockCursor();
    }
    private void LateUpdate()
    {
        if (Player != null)
        {
            transform.position = Player.position;
        }
       
        

        if (Cursor.lockState == CursorLockMode.Locked)
        {
            yaw += Input.GetAxis("Mouse X") * MouseSensitivity;
            pitch -= Input.GetAxis("Mouse Y") * MouseSensitivity;

            pitch = Mathf.Clamp(
                pitch,
                minVerticalAngle,
                maxVerticalAngle
                );
        }
        transform.rotation = Quaternion.Euler(pitch, yaw, 0f);
        
    }
    void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible=false;
    }
}