using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            SceneManager.LoadScene("LVL_2");
        }
    }

    public void LoadNewScene()
    {
        SceneManager.LoadScene("LVL_2");
    }
}
