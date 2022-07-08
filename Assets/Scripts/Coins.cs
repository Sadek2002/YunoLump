using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{

    IEnumerator SavePlayerData()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", DBManager.username);
        form.AddField("score", DBManager.score);

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
         DBManager.LogOut();
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

      private void OnTriggerEnter2D(Collider2D collision) 
         {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            DBManager.score++;
            
        }
    }
}