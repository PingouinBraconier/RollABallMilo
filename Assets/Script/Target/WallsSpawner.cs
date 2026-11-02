using UnityEngine;

public class WallsSpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform spawnPosition;
    
       
    public void SpawnNewWall()
    {
        Instantiate(prefab, spawnPosition);
    }


}
