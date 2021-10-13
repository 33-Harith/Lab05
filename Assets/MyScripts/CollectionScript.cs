using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CollectionScript : MonoBehaviour
{
    public Text CoinCount;
    public int Coin;

    public float timeLeft;
    public int timeRemaining;

    public Text TimerText;

    public float TimerValue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        timeRemaining = Mathf.FloorToInt(timeLeft % 60);
        TimerText.text = "Timer : " + timeRemaining.ToString();

        if (timeLeft <= 0)
        {
            SceneManager.LoadScene("LoseScene");
        }
        CoinCount.GetComponent<Text>().text = "Coins : " + Coin;
        if (Coin >= 60)
        {
            SceneManager.LoadScene("WinScene");
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            Destroy(other.gameObject);
            Coin += 10;
        }
        if (other.gameObject.tag == "Water")
        {
            SceneManager.LoadScene("LoseScene");
        }
    }
}
