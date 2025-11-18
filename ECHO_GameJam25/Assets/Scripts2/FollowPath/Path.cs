using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.TextCore.Text;
using UnityEngine.UIElements;

public class Path : MonoBehaviour
{
    [SerializeField]
    private Transform[] Points;

    [SerializeField]
    private GameObject light;

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject respawnPoint;

    [SerializeField]
    private float lightDistanceTrigger;

    private int pointIndex;

    private Vector3 initialTriggerPos;
    private Vector3 initialLightPos;


    private bool movedOnce = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pointIndex = 0;
        light.transform.position = Points[pointIndex].transform.position;
        initialTriggerPos = transform.position;
        initialLightPos = light.transform.position;


    }

    // Update is called once per frame
    void Update()
    { 

        //Reseter
        if(player.transform.position == respawnPoint.transform.position)
        {
            pointIndex = 0;
            transform.position = initialTriggerPos;
            light.transform.position = initialLightPos;
        }

        if (Vector3.Distance(light.transform.position, player.transform.position) <= lightDistanceTrigger && pointIndex<Points.Length - 1 && !movedOnce)
        {
            if(Vector3.Distance(player.transform.position, Points[pointIndex+1].transform.position) > lightDistanceTrigger)
            {
                pointIndex++;
                movedOnce = true;
            }
            else if(pointIndex + 2 < Points.Length -1)
            {
                pointIndex += 2;
                movedOnce = true;
            }
        }


        if (Vector3.Distance(light.transform.position, player.transform.position) > lightDistanceTrigger)
            movedOnce = false;



        if (pointIndex <= Points.Length - 1)
        {
            light.transform.position = Vector3.MoveTowards(light.transform.position, Points[pointIndex].transform.position, moveSpeed * Time.deltaTime);
        }

        
            
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //moves the light
        if(light.transform.position == Points[pointIndex].transform.position && pointIndex < Points.Length - 1) 
            pointIndex += 1;
        //moves the trigger
        if (pointIndex != 0)
            transform.position = Points[pointIndex - 1].transform.position;
        else
        {
            transform.position = initialLightPos;
        }

    }
}
