using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float jumpForce = 5f;
    
    [SerializeField] private LayerMask groundLayer;
    private Rigidbody rb;
    private bool isGrounded;
    private float normalJumpForce;
    [SerializeField] private Coroutine superJumpCoroutine;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        normalJumpForce = jumpForce;
    }



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }



    private void OnCollisionStay(Collision collision)
    {
        if (((1 << collision.gameObject.layer) & groundLayer.value) != 0)
        {
            isGrounded = true;
        }
    }


    void OnCollisionExit(Collision collision)
    {
        if (((1 << collision.gameObject.layer) & groundLayer.value) != 0)
        {
            isGrounded = false;
        }

    }

}
