using UnityEngine;

public class PlayerCollect : MonoBehaviour
{
    [SerializeField] private ScoreDatas scoreData;
    [SerializeField] private UICoontroller uiController;
    [SerializeField] private SpawnController spawnController;

    private void OnTriggerEnter(Collider other)
    {
        Target target = other.gameObject.GetComponent<Target>();
        Debug.Log("touch smthg");
        if (other.gameObject.GetComponent<Target>())
        {
            
            scoreData.Score = scoreData.Score + target.ScoreValue;
            uiController.UpdateScoreText(scoreData.Score);
            spawnController.OnTargetDestroyed(target);
            Debug.Log("touch smthg");
            Destroy(other.gameObject);
            GetComponent<ColorFeedback>().StartHighlight();
            
        }
    }
   
} 
    
