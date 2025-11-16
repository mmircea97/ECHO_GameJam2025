using UnityEngine;

public class PlatformMoving : MonoBehaviour
{
    [SerializeField]
    Transform rBound;

    [SerializeField]
    Transform lBound;

    [SerializeField]
    float movSpeed;

    private Vector3 nextPosition;
    private Vector3 startrBound;
    private Vector3 startlBound;

    private void Start()
    {
        nextPosition = rBound.position;
        startrBound = rBound.position;
        startlBound = lBound.position;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, nextPosition, movSpeed * Time.deltaTime);
        Debug.Log("transform.position");

        if (transform.position == nextPosition)
        {
            if (nextPosition == startrBound)
            {
                nextPosition = startlBound;
            }

            else if (nextPosition == startlBound)
            {
                nextPosition = startrBound;
            }
        }

    }
}
