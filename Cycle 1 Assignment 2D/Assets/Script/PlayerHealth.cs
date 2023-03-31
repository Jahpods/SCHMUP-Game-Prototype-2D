using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 10;
    private int damage = 1;

    public void TakeDamage()
    {
        health -= damage;
        if(health == 0)
        {
            Destroy(this.gameObject);
        }
    }
}
