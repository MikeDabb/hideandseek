using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class DisplayNumberOfPlayersInRoom : MonoBehaviour
{
    public Text numberOfPlayersText;

    void Start()
    {
        numberOfPlayersText = GetComponent<Text>();
    }

    void Update()
    {
        DisplayNumberOfPlayersCurrentlyInRoom();
    }

    private void DisplayNumberOfPlayersCurrentlyInRoom()
    {
        Debug.Log("Count Of Players In Rooms: " + PhotonNetwork.PlayerList.Length);
        numberOfPlayersText.text = string.Format("Count Of Players In Rooms: {0} ", PhotonNetwork.PlayerList.Length);
    }
}
