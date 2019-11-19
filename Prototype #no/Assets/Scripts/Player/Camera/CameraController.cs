
using UnityEngine;
using Photon.Pun;

[RequireComponent(typeof(GameObject))]
[RequireComponent(typeof(PhotonView))]
public class CameraController : MonoBehaviour
{
    public GameObject thirdPersonCamera;
    private PhotonView photonView;

    void Start()
    {
        photonView = GetComponent<PhotonView>();
        if (photonView.IsMine)
        {
            Debug.LogFormat("photonView.IsMine: {0}", photonView.IsMine);
            //thirdPersonCamera.SetActive(true);
        }

        else
        {
            return;
        }
    }

    void Update()
    {
        
    }
}
