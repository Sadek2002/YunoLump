using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelSelection : MonoBehaviour
{
    public Button Level1;
    public Button Level2;
    public Button Level3;
    public Button Bossfight;
    public Button Menu;

    public void GoToLevel1()
    {
        SceneManager.LoadScene(6);
    }
    public void GoToLevel2()
    {
        SceneManager.LoadScene(7);
    }
    public void GoToLevel3()
    {
        SceneManager.LoadScene(8);
    }
    public void GoToLevelBossfight()
    {
        SceneManager.LoadScene(9);
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene(3);
    }
}