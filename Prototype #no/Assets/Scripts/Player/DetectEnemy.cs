using UnityEngine;

public class DetectEnemy : MonoBehaviour
{

    public GameObject playerTwo;
    public Material playerTwoMaterial;

    void Start()
    {
        GameObject playerTwo = GetComponent<GameObject>();
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
            playerTwoMaterial.EnableKeyword("_EMISSION");
        }
    }
}
