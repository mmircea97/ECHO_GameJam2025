using Unity.VisualScripting;
using UnityEngine;

public class MapReveal : MonoBehaviour
{
    [SerializeField]
    private GameObject gameObject;


    [SerializeField]
    private float maxDistance;

    private float dimension;

    [SerializeField]
    private float scaleMultiplier;

    void Start()
    {
    }


    // Update is called once per frame
    void Update()
    {
        dimension = (1 / Vector2.Distance(this.transform.position, gameObject.transform.position) / maxDistance) * scaleMultiplier;
        Debug.Log(Vector2.Distance(this.transform.position, gameObject.transform.position));
        this.transform.localScale = new Vector3(dimension, dimension, dimension);
    }
}
