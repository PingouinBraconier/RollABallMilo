using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelZone : MonoBehaviour
{
    [SerializeField] private LayerMask NextLevelLayer;
   
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (((1 << collision.gameObject.layer) & NextLevelLayer.value) != 0)
        {
            SceneManager.LoadScene("Lvl_2");
        }
    }
}
