using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreasePoints : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && gameManager != null)
        {
            gameManager.IncreaseScore(1);
            gameObject.SetActive(false);
        }
    }
}