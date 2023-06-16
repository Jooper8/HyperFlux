using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float knockbackDuration = 0.5f;
    [SerializeField] float knockbackForce = 5f;
    [SerializeField] float upwardForce = 5f;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource audioSourceMusic;
    private bool isMoving;
    private Rigidbody2D rb;
    private bool isKnockbackActive = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        rb.velocity = new Vector2(0f, upwardForce);
    }
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Stationary)
            {
                isMoving = true;
                HandleInput(touch.position);
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                isMoving = false;
            }
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            HandleInput(mousePosition);
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
    }
    private void FixedUpdate()
    {
        if (!isMoving)
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }
    }
    private void HandleInput(Vector3 inputPosition)
    {
        float horizontalMovement = inputPosition.x < Screen.width / 2 ? -1f : 1f;
        Vector2 velocity = new Vector2(horizontalMovement * movementSpeed, rb.velocity.y);
        rb.velocity = velocity;
    }
    /*private void FixedUpdate()
    {
        if (isKnockbackActive)
        {
            knockbackDuration -= Time.fixedDeltaTime;
            if (knockbackDuration <= 0f)
            {
                isKnockbackActive = false;
                rb.velocity = Vector2.zero;
                Time.timeScale = 1f;
            }
        }
    }*///Old knockback method
    public void ApplyKnockback()
    {
        StartCoroutine(KillPlayer());
    }
    private IEnumerator KillPlayer()
    {
        audioSourceMusic.Stop();
        audioSource.Play();
        PlayerController playerController = GetComponent<PlayerController>();
        playerController.enabled = false;
        Vector2 knockbackDirection = -transform.up;
        rb.velocity = knockbackDirection * knockbackForce;
        float torque = 20f;
        rb.AddTorque(torque, ForceMode2D.Impulse);
        yield return new WaitForSeconds(1.5f);
        GameManager.Instance.GameOver();
        Time.timeScale = 0f;
    }
}
