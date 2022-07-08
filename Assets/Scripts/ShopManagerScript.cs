using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopManagerScript : MonoBehaviour
{

    public Text playerDisplay;
    public Text scoreDisplay;
    public Text healthDisplay;
    public Button item1;

    private void Awake()
    {
        if (DBManager.username == null)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
        playerDisplay.text = "Player: " + DBManager.username;
        scoreDisplay.text = "Score: " + DBManager.score;
        healthDisplay.text = "Current Health: " + DBManager.maxhealth;
    }

    public void CallSaveData()
    {
        StartCoroutine(SavePlayerData());
    }

    IEnumerator SavePlayerData()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", DBManager.username);
        form.AddField("score", DBManager.score);
        form.AddField("health", DBManager.maxhealth);

        WWW www = new WWW("http://localhost/sqlconnect/savedata.php", form);
        yield return www;
        if (www.text == "0")
        {
            Debug.Log("Game Saved.");
        }
        else
        {
            Debug.Log("Game failed to save. Error #6" + www.text); //Game couldn't save
        }
        UnityEngine.SceneManagement.SceneManager.LoadScene(3);

    }

    public void GetHealth()
    {
        if (DBManager.maxhealth <= 9 && DBManager.score >= 10)
        {
            item1.interactable = true;
            DBManager.score = DBManager.score - 10;
            DBManager.maxhealth++;
            healthDisplay.text = "Health: " + DBManager.maxhealth;
            scoreDisplay.text = "Score: " + DBManager.score;
        }
        else if (DBManager.maxhealth >= 10 || DBManager.score <= 9)
        {
            item1.interactable = false;
        }
    }
}