using TMPro;
using UnityEngine;

public class TotalRoomDeaths : MonoBehaviour
{
    [SerializeField]
    private GameObject r2Deaths;

    [SerializeField]
    private GameObject r3Deaths;

    [SerializeField]
    private GameObject r4Deaths;



    [SerializeField]
    private TMP_Text totalDeathCounter;





    private void Update()
    {
        totalDeathCounter.text = (r2Deaths.GetComponent<RoomDeathCounter>().deathCounter + r3Deaths.GetComponent<RoomDeathCounter>().deathCounter + r4Deaths.GetComponent<RoomDeathCounter>().deathCounter).ToString();
    }
}
