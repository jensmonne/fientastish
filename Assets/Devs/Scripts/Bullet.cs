using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Destroy the bullet on collision with any object
        Destroy(gameObject);

        if(collision.gameObject.CompareTag("Player"))
        {
            // Optionally, you can add logic here to damage the enemy
            Debug.Log("Player hit!");
        }
    }

    void Update()
    {
        Timer();
    }

    void Timer()
    {
        // Destroy the bullet after 5 seconds to prevent it from existing indefinitely
        Destroy(gameObject, 5f);
    }
}
