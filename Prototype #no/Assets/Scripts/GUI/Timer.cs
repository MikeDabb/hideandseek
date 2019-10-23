using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    Text timer;
    public float timeUntilFinish = 60f;

    void Start()
    {
        timer = GetComponent<Text>();
    }

    void Update()
    {
        CountTimeUntilGameOver();
    }

    private void CountTimeUntilGameOver()
    {
        timer.text = Mathf.RoundToInt(timeUntilFinish).ToString();
        timeUntilFinish -= Time.deltaTime;
        if (Mathf.RoundToInt(timeUntilFinish) == 0)
        {
            timeUntilFinish = 0f;
            timer.text = "It's over!";
            timer.color = Color.red;
            timer.fontSize = 40;
        }
    }
}
