using UnityEngine;

public class Bouncer : MonoBehaviour
{
    [SerializeField] private LayerMask bouncerLayer;
    [SerializeField] private float bounceForce = 10f;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (((1 << collision.gameObject.layer) & bouncerLayer.value) != 0)
        {
            rb.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
        }
    }
}
