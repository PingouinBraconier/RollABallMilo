using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnLogic : MonoBehaviour
{
    [SerializeField] public Transform SpawnPoint;
    [SerializeField] private LayerMask WaterLayer;
    [SerializeField] private GameObject DefeatMenu;
    [SerializeField] private string level;
    private Rigidbody rb;
    private bool isDead = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        DefeatMenu.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (((1 << collision.gameObject.layer) & WaterLayer.value) != 0)
        {
            if (isDead)
                return;

            isDead = true;

            // Mettre le jeu en pause
            Time.timeScale = 0f;

            // Afficher le menu de défaite
            DefeatMenu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;

            
        }
    }
    private void Update()
    {
        if (isDead && Input.GetMouseButtonDown(0))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(level);
        }
    }
}
