using UnityEngine;
using UnityEngine.SceneManagement;

using Photon.Pun;
using Photon.Realtime;
using System.Collections;

public class GameManager : MonoBehaviourPunCallbacks
{
    #region Public Fields
    [Tooltip("The prefab to use for instantiating Player One")]
    public GameObject playerOnePrefab;

    [Tooltip("The pregab to use for instantiating Player Two")]
    public GameObject playerTwoPrefab;

    [Tooltip("Material to use for emission checking (meaning that the player was spotted)")]
    public Material playerTwoMaterial;
    public GameObject gameFinishedUI;
    #endregion

    #region Photon Callbacks

    public override void OnPlayerEnteredRoom(Player other)
    {
        Debug.LogFormat("OnPlayerEnteredRoom() {0}", other.NickName); // not seen if you're the player connecting

        if (PhotonNetwork.IsMasterClient)
        {
            Debug.LogFormat("OnPlayerEnteredRoom IsMasterClient {0}", PhotonNetwork.IsMasterClient); // called before OnPlayerLeftRoom
            LoadArena();
        }
    }

    public override void OnPlayerLeftRoom(Player other)
    {
        Debug.LogFormat("OnPlayerLeftRoom() {0}", other.NickName); // seen when other disconnects


        if (PhotonNetwork.IsMasterClient)
        {
            Debug.LogFormat("OnPlayerLeftRoom IsMasterClient {0}", PhotonNetwork.IsMasterClient); // called before OnPlayerLeftRoom
            LoadArena();
        }
    }

    /// <summary>
    /// Called when the local player left the room. We need to load the launcher scene
    /// </summary>
    /// 
    public override void OnLeftRoom()
    {
        SceneManager.LoadScene(0);
    }
    #endregion

    #region Monobehaviour Callbacks
    public void Start()
    {
        DisableGameFinishedUI();
        playerTwoMaterial.DisableKeyword("_EMISSION");
        if (playerOnePrefab == null)
        {
            Debug.LogError("<Color=Red><a>Missing</a></Color> playerPrefab Reference. Please set it up in GameObject 'Game Manager'", this);
        }

        InstantiatePlayer();
        //if (Movement.LocalPlayerInstance == null)
        //{
        //    Debug.LogFormat("We are Instantiating LocalPlayer from {0}", SceneManagerHelper.ActiveSceneName);
        //    // we're in a room. spawn a character for the local player. it gets synced by using PhotonNetwork.Instantiate
        //    PhotonNetwork.Instantiate(playerOnePrefab.name, new Vector3(0f, 5f, 0f), Quaternion.identity, 0);

        //}
        //else
        //{
        //    Debug.LogFormat("Ignoring scene load for {0}", SceneManagerHelper.ActiveSceneName);
        //}
    }

    public void Update()
    {
        FinishGameAfterPlayerTwoIsSpotted();
        DisplayPlayersCurrentlyInRoom();
    }
    #endregion

    #region Public Methods
    // Update is called once per frame
    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }
    #endregion

    #region Private Methods
    void LoadArena()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            Debug.LogError("PhotonNetwork : Trying to Load a level but we are not the master Client");
        }
        Debug.LogFormat("PhotonNetwork : Loading Level : {0}", PhotonNetwork.CurrentRoom.PlayerCount);
        PhotonNetwork.LoadLevel("Room for " + PhotonNetwork.CurrentRoom.PlayerCount);
    }

    // changes emission to true for material used by player two, which results in player two being lighted up
    private void FinishGameAfterPlayerTwoIsSpotted()
    {
        if (playerTwoMaterial.IsKeywordEnabled("_EMISSION"))
        {
            gameFinishedUI.SetActive(true);
        }
    }

    // makes sure UI text for finished game is not displayed at the beggining of the game
    private void DisableGameFinishedUI()
    {
        gameFinishedUI.SetActive(false);
    }

    private void DisplayPlayersCurrentlyInRoom()
    {
        Debug.Log("Count Rooms:" + PhotonNetwork.CountOfRooms);
        Debug.Log("Count Of Players In Rooms:" + PhotonNetwork.CountOfPlayersInRooms);
    }

    private void InstantiatePlayer()
    {
        // make sure that local player is not yet instantiated and check for players count (if 1 then PlayerOne, if 2 then PlayerTwo)
        if (Movement.LocalPlayerInstance == null)
        {
            if (PhotonNetwork.IsMasterClient)
            {
                Debug.LogFormat("We are Instantiating LocalPlayer from {0}", SceneManagerHelper.ActiveSceneName);
                // we're in a room. spawn a character for the local player. it gets synced by using PhotonNetwork.Instantiate
                PhotonNetwork.Instantiate(playerOnePrefab.name, new Vector3(-12f, 5f, 0f), Quaternion.identity, 0);
            }
            else
            {
                Debug.LogFormat("We are Instantiating LocalPlayer from {0}", SceneManagerHelper.ActiveSceneName);
                // we're in a room. spawn a character for the local player. it gets synced by using PhotonNetwork.Instantiate
                PhotonNetwork.Instantiate(playerTwoPrefab.name, new Vector3(12f, 5f, 0f), Quaternion.identity, 0);
            }
        }
        else
        {
            Debug.LogFormat("Ignoring scene load for {0}", SceneManagerHelper.ActiveSceneName);
        }
    }
    #endregion


}
