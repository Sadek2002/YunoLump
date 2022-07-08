using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDamage : MonoBehaviour
{
    [SerializeField] private float damage;
    public float attackRate = 54f;
    float nextAttackTime = 0f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Time.time >= nextAttackTime)
        {
            if (collision.tag == "Player")
            {
                collision.GetComponent<Health>().TakeDamage(damage);
                nextAttackTime = Time.time + 2f / attackRate;
            }
        }
    }
}
