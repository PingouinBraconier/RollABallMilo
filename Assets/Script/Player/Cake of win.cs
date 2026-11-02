using UnityEngine;

public class CakeOfWin : MonoBehaviour
{
    [SerializeField] private LayerMask CakeLayer;
    [SerializeField] private GameObject winMenu;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        winMenu.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (((1 << collision.gameObject.layer) & CakeLayer.value) != 0)
        {
            // Mettre le jeu en pause
            Time.timeScale = 0f;

            // Afficher le menu de victoire
            winMenu.SetActive(true);
        }
    }
}
