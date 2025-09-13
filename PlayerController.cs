using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public GameObject bulletPrefab; // Mermi prefab'�
    public Transform firePoint; // Ate�leme noktas�
    public AudioSource audioSource; // AudioSource referans�
    public Transform cameraTransform; // Kamera referans�
    private bool isGrounded;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            Shoot();
        }

        UpdateCameraPosition(); // Kamera pozisyonunu g�ncelle
    }

    void Move()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Top sesini �al
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
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
            newCameraPosition.x = transform.position.x; // Kamera X ekseninde oyuncuyu takip eder
            newCameraPosition.y = transform.position.y; // Kamera Y ekseninde oyuncuyu takip eder (iste�e ba�l�)
            cameraTransform.position = newCameraPosition;
        }
    }
}
