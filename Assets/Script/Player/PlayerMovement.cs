using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody rb;
    [SerializeField]  private float speed = 2f;
    [SerializeField]  private Transform cameraTarget;
    private float horizontalVelocityOnX;
    private float horizontalVelocityOnZ;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (cameraTarget == null && Camera.main != null)
        {
            cameraTarget = Camera.main.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        horizontalVelocityOnX = 0f;
        horizontalVelocityOnZ = 0f;

        if (Input.GetKey(KeyCode.D))
            horizontalVelocityOnX = 1f;
        else if (Input.GetKey(KeyCode.A))
            horizontalVelocityOnX = -1f;

        if (Input.GetKey(KeyCode.W))
            horizontalVelocityOnZ = 1f;
        else if (Input.GetKey(KeyCode.S))
            horizontalVelocityOnZ = -1f;
    }
    private void FixedUpdate()
    {
        if (cameraTarget == null)
            return;

        // Direction avant du CameraTarget
        Vector3 forward = cameraTarget.forward;
        forward.y = 0f;
        forward.Normalize();

        // Direction droite du CameraTarget
        Vector3 right = cameraTarget.right;
        right.y = 0f;
        right.Normalize();

        // Calculer le déplacement par rapport à la caméra
        Vector3 movement =
            forward * horizontalVelocityOnZ +
            right * horizontalVelocityOnX;

        // Éviter d'aller plus vite en diagonale
        movement = Vector3.ClampMagnitude(movement, 1f);

        // Appliquer la vitesse en conservant la vitesse verticale
        rb.linearVelocity = new Vector3(
            movement.x * speed,
            rb.linearVelocity.y,
            movement.z * speed
        );
    }
}
