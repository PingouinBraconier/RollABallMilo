using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class SpawnController : MonoBehaviour
{
    [SerializeField] private List<Target> targets;
    [SerializeField] private List<WallsSpawner> wallSpawners;
    private int actualIndex = 0;
    [SerializeField] private LevelManager levelManager;
    

    public void OnTargetDestroyed(Target targetDestroyed)
    {
        if (targets.Contains(targetDestroyed)) 
        {
            targets.Remove(targetDestroyed);
            if(targets.Count <= 0)
            {
                //victoire
                levelManager.LoadNewScene();
            }
            else if (actualIndex < wallSpawners.Count)
            {
                //spawn New WALL
                wallSpawners[actualIndex].SpawnNewWall();
            }
        }
        
        
        //faut ecrire là dedans sinon ça sert à rien
    }
 
}
