using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f; // Merminin h�z�
    public float lifeTime = 3f; // Merminin �mr�

    void Start()
    {
        Destroy(gameObject, lifeTime); // Belirli bir s�re sonra mermiyi yok et
    }

    void Update()
    {
        // Mermiyi ileri do�ru hareket ettir
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �arpt���nda mermiyi yok et
        Destroy(gameObject);
    }
}
