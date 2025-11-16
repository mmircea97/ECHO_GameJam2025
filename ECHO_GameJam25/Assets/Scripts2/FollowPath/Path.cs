using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField]
    private Transform[] Points;

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float jitterAmount;

    [SerializeField]
    private float jitterSpeed;

    [SerializeField]
    private float distanceFromPointThreshold;

    private int pointIndex;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //pointIndex = 0;
        transform.position = Points[pointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (pointIndex <= Points.Length - 1)
        {
            Vector3 jitteredPosition = new Vector3(Mathf.Sin(Time.time * jitterSpeed) * jitterAmount, Mathf.Cos(Time.time * jitterSpeed) * jitterAmount, 0);
            transform.position = Vector2.MoveTowards(transform.position, Points[pointIndex].transform.position, moveSpeed * Time.deltaTime);

            transform.position += jitteredPosition;

            if (Vector2.Distance(transform.position,Points[pointIndex].transform.position) < distanceFromPointThreshold)
            {
                pointIndex += 1;
            }
            
            if(pointIndex == Points.Length)
            {
                pointIndex = 0;
            }
        }
            
    }
}
