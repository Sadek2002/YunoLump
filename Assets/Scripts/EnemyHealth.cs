using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public Animator animator;

    public int maxHealth = 1;
    int currentHealth;
    [SerializeField] private AudioClip monsterhurt;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void HurtRabutto(int damage)
    {
        currentHealth -= damage;
        SoundManager.instance.PlaySound(monsterhurt);
        animator.SetTrigger("Hurt");

        if (currentHealth <= 0 && gameObject.tag == "Rabutto")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(3);
            Die();
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        SoundManager.instance.PlaySound(monsterhurt);
        animator.SetTrigger("Hurt");

        if(currentHealth <= 0 && gameObject.tag == "Rabutto")
        {
            Die();
            UnityEngine.SceneManagement.SceneManager.LoadScene(3);
        } else if(currentHealth <= 0)
        {
            Die();
        }
    }


    void Die()
    {
        Debug.Log("Enemy died!");
        // Die animation
        animator.SetBool("IsDead", true);
        // Disable the enemy
        this.enabled = false;
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        Destroy(gameObject);
    }
}
