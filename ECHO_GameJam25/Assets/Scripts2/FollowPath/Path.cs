using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField]
    private Transform[] Points;

    [SerializeField]
    private float moveSpeed;

    private int pointIndex;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = Points[pointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    { 
        if (pointIndex <= Points.Length - 1)

        {
            transform.position = Vector3.MoveTowards(transform.position, Points[pointIndex].transform.position, moveSpeed * Time.deltaTime);

            if (transform.position == Points[pointIndex].transform.position)
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
