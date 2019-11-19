using UnityEngine;


public class DetectPlayerWithFlashlight : MonoBehaviour
{
    public Material playerTwoMaterial;

    public bool isPlayerTwoSeen;

    void Start()
    {
        Material playerTwoMaterial = GetComponent<Material>();
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerTwo")
        {
            Debug.Log("Player one wins!");
            EnableEmissionOnPlayerTwoMaterial();
        }
    }

    public void EnableEmissionOnPlayerTwoMaterial()
    {
        playerTwoMaterial.EnableKeyword("_EMISSION");
    }
}
