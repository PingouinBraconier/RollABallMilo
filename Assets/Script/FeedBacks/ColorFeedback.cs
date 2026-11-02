using System.Collections;
using UnityEngine;

public class ColorFeedback : MonoBehaviour
{
    [SerializeField] private Material newMaterial;
    [SerializeField] private Material originMaterial;
    [SerializeField] private float timer;
    [SerializeField] private float feedbackDuration;
    [SerializeField] private bool isHighlight;



    private void Start()
    {
        originMaterial = GetComponent<MeshRenderer>().material;

    }
    public void ChangeMaterial(Material newMat)
    {
        GetComponent<MeshRenderer>().material = newMat;
        timer = 0;

    }
    
    private void FixedUpdate()
    {
        timer = timer + Time.fixedDeltaTime;
        if (isHighlight)
        {
            if (timer > feedbackDuration)
            {
                timer = 0;
                isHighlight = false;
                ChangeMaterial(originMaterial);
            }
        }
        
    }
    public void StartHighlight()
    {
        StartCoroutine(TempoCoroutine());
        //changematerial(newmaterial);
        //ishighlight = true;
    }

    IEnumerator TempoCoroutine()
    {
        ChangeMaterial(newMaterial);
        yield return new WaitForSeconds(feedbackDuration);
        ChangeMaterial(originMaterial);
    }
}

