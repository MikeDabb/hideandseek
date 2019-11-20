using System.Collections;
using UnityEngine;

[RequireComponent(typeof(GameObject))]
public class DetectPlayerWithLaser : MonoBehaviour
{
    public GameObject cameraLight;
    public Material playerTwoMaterial;

    public bool isPlayerTwoSeen;

    void Start()
    {
        isPlayerTwoSeen = false;
        cameraLight.SetActive(false);
    }

    void Update()
    {
        LightOnDetection();
        //ResetCameraLightAfter5Seconds();
    }

    private void LightOnDetection()
    {
        if (isPlayerTwoSeen)
        {
            EnableCameraLight();
            EnableEmissionOnPlayerTwoMaterial();
            isPlayerTwoSeen = false;
        }

    }

    private void EnableCameraLight()
    {
        cameraLight.SetActive(true);
        Debug.Log("Player Two has been spotted");
    }

    //private void ResetCameraLightAfter5Seconds()
    //{
    //    StartCoroutine(DisableLightAfterTime(5f));
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerTwo")
            isPlayerTwoSeen = true;
    }

    //private IEnumerator DisableLightAfterTime(float seconds)
    //{
    //    yield return new WaitForSeconds(seconds);
    //    cameraLight.SetActive(false);
    //}

    private void EnableEmissionOnPlayerTwoMaterial()
    {
        playerTwoMaterial.EnableKeyword("_EMISSION");
    }
}
