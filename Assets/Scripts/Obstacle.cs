using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacle : MonoBehaviour
{
    public float lifeTime = 5f;
    public float knockbackForce = 5f;
    private bool isPlayerKilled = false;
    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isPlayerKilled && collision.gameObject.CompareTag("Player"))
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            player.ApplyKnockback();
        }
    }
}
