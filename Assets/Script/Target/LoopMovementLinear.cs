using UnityEngine;

public class LoopMovementLinear : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPointArray;
    [SerializeField] private float distancePecentage;
    [SerializeField] private float speed;
    [SerializeField] private float timer;
    [SerializeField] private float actualDistance; 
    [SerializeField] private float maxDistance;
    [SerializeField] private int origineIndex = 0;
    [SerializeField] private int endIndex = 1;

    private void Start()
    {
        maxDistance = Vector3.Distance(spawnPointArray[0].position, spawnPointArray[1].position);
    }

    private void FixedUpdate()
    {
        timer = timer + Time.fixedDeltaTime;
        actualDistance = actualDistance + timer * speed;
        distancePecentage = actualDistance / maxDistance;
        transform.position = Vector3.Lerp(spawnPointArray[origineIndex].position, spawnPointArray[endIndex].position, distancePecentage);
        if (actualDistance >= maxDistance)
        {
            timer = 0;
            actualDistance = 0;
            origineIndex = (origineIndex+1) % spawnPointArray.Length;
            endIndex = (endIndex+1) % spawnPointArray.Length;
            maxDistance = Vector3.Distance(spawnPointArray[origineIndex].position, spawnPointArray[endIndex].position);
        }

    }

}
