using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.parent.CompareTag("Player"))
        {
            Destroy(gameObject);
            Player.score++;
        }
    }
}
