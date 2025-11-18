using UnityEngine;
using UnityEngine.InputSystem;

public class RoomDeathCounter : MonoBehaviour
{
    private Vector3 lastPosition;

    [SerializeField]
    private float distanceThreshold;

    [SerializeField]
    private TMPro.TMP_Text m_TextMeshPro;

    public int deathCounter;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        deathCounter = 0;
        lastPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (MovedALot())
        {
            deathCounter++;
            m_TextMeshPro.text = deathCounter.ToString();
        }
        lastPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    private bool MovedALot()
    {
        if (GameObject.FindGameObjectWithTag("Player").transform.position == transform.position && Mathf.Abs(Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, lastPosition)) > distanceThreshold && !Keyboard.current.digit1Key.isPressed && !Keyboard.current.digit2Key.isPressed && !Keyboard.current.digit3Key.isPressed && !Keyboard.current.digit4Key.isPressed)
            return true;
        return false;
    }
}
