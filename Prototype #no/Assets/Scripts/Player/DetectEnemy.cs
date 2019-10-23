using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DetectEnemy : MonoBehaviour
{

    public GameObject playerWonUI;

    // Start is called before the first frame update
    void Start()
    {
        GameObject playerWonUI = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerTwo")
        {
            playerWonUI.SetActive(true);
            Debug.Log("Player one wins!");
        }
    }
}
