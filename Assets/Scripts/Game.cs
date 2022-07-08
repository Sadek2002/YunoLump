using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{

    public Text playerDisplay;
    public Text scoreDisplay;
    public Text maxHealthDisplay;
    [SerializeField] private AudioClip gold;

    private void Awake()
    {
        if (DBManager.username == null)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
        playerDisplay.text = "Player: " + DBManager.username;
        scoreDisplay.text = "Score: " + DBManager.score;
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

    private void OnTriggerEnter2D(Collider2D collision) 
         {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            DBManager.score++;
            scoreDisplay.text = "Score: " + DBManager.score;
            SoundManager.instance.PlaySound(gold);
        }
    }
}