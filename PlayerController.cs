using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public AudioSource audioSource;
    public Transform cameraTransform;
    private bool isGrounded;
    private Rigidbody2D rb;
    private Animator animator;
    private Vector3 startPosition;
    private bool isGameOver = false;
    private bool isDead = false;
    public bool anahtarAlindi = false;
    public float deathYuksekligi = -90f;
    public GameObject sandikKapali;
    public GameObject sandikAcik;
    public Timer timer;
    public ScoreManager scoreManager;
    public GameObject gameOverPanel;
    public GameObject Anahtar;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
        animator = GetComponent<Animator>();
        sandikAcik.SetActive(false);
        sandikKapali.SetActive(true);
        scoreManager.olumsayaci = 0;
        gameOverPanel.SetActive(false);
    }
    void Update()
    {
        if (!isGameOver)
        {
            Move();
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                Jump();
            }
            if (Input.GetMouseButtonDown(0))
            {
                Shoot();
            }
            UpdateCameraPosition();
            DustukMu();
        }
    }
    void Move()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
        animator.SetBool("isRunning", moveInput != 0);
    }
    void Jump()
    {
        if (!isDead)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            animator.SetBool("isJumping", true);
        }
    }
    void Shoot()
    {
        if (!isDead)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            animator.SetBool("isShooting", true);
            if (audioSource) audioSource.Play();
            Invoke("StopShooting", 2f);
        }
    }
    void StopShooting() => animator.SetBool("isShooting", false);
    void Die()
    {
        if (!isDead)
        {
            animator.SetBool("isDead", true);
            isDead = true;
            rb.linearVelocity = Vector2.zero;
            scoreManager.olumsayaci++;
            scoreManager.OlumuGuncelle();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("isJumping", false);
        }
        if (collision.gameObject.CompareTag("Spike") && !isGameOver)
        {
            rb.linearVelocity = Vector2.zero;
            isGameOver = true; 
            Die();
            Invoke("RestartGame", 2f); 
        }
        if (collision.gameObject.CompareTag("Key"))
        {
            Anahtar.SetActive(false);
            anahtarAlindi = true;
        }
        if (collision.gameObject.CompareTag("Sandik") && anahtarAlindi == true)
        {                
            sandikKapali.SetActive(false);  
            sandikAcik.SetActive(true);
            timer.gameOver = true;
            Invoke("ShowGameOverPanel", 1f);
            gameOverPanel.SetActive(true);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
    void UpdateCameraPosition()
    {
        if (cameraTransform != null)
        {
            Vector3 newCameraPosition = cameraTransform.position;
            newCameraPosition.x = transform.position.x;
            newCameraPosition.y = transform.position.y;
            cameraTransform.position = newCameraPosition;
        }
    }
    void RestartGame()
    {
        transform.position = startPosition;
        animator.SetBool("isDead", false);
        animator.SetBool("isJumping", false);
        animator.SetBool("isRunning", false);
        animator.SetBool("isShooting", false);
        isGameOver = false;
        isDead = false;
        rb.linearVelocity = Vector2.zero;
    }
    void DustukMu()
    {
        if (transform.position.y < deathYuksekligi)
        {
            Die();
            RestartGame(); 
        }
    }
    public void TekrarOyna() 
    {
        transform.position = startPosition;
        isGameOver = false;
        isDead = false;
        gameOverPanel.SetActive(false);
        timer.gameOver = false;
        timer.timeElapsed = 0f;
        Anahtar.SetActive(true);
        anahtarAlindi = false;
        sandikAcik.SetActive(false);
        sandikKapali.SetActive(true);
        scoreManager.olumsayaci = 0;
        scoreManager.OlumuGuncelle();
    }
}
