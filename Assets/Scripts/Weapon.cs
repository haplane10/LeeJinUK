using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] int power;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Enemy"))
    //    {
    //        var enemy = collision.GetComponent<EnemyController>();
    //        enemy.Damage(power);
    //    }
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            var enemy = collision.transform.GetComponent<EnemyController>();
            enemy.Damage(power);
        }
    }
}
