using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoDamage : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            Destroy(this.gameObject);
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage();
        }
    }
}
