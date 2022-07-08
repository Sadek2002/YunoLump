using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;
    public Text healthDisplay;
    [SerializeField] private AudioClip hurt;

    private void Awake()
    {
        currentHealth = DBManager.maxhealth;
        anim = GetComponent<Animator>();
    }

    IEnumerator SavePlayerData()
    {
        WWWForm form = new WWWForm();

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

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, DBManager.maxhealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("Hurt");
            SoundManager.instance.PlaySound(hurt);
            //iframes
        }
        else
        {
            if(!dead)
            {
                anim.SetTrigger("Die");
                GetComponent<PlayerMovement>().enabled = false;
                UnityEngine.SceneManagement.SceneManager.LoadScene(3);

            }
            dead = true;
        }
    }
}
