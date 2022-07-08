using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    public Button LevelSelection;
    public Button Shop;
    public Button ExitGame;
    public Button Controls;
    public Button MainMenu;

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

    public Text playerDisplay;

    public void GoToLevelSelection()
    {
        SceneManager.LoadScene(5);
    }
    public void GoToShop()
    {
        SceneManager.LoadScene(4);
    }
    public void GoToExit()
    {
        DBManager.LogOut();
        SceneManager.LoadScene(0);
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene(3);
    }
    public void GoToControls()
    {
        SceneManager.LoadScene(10);
    }
}
