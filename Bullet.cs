using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f; // Merminin hýzý
    public float lifeTime = 3f; // Merminin ömrü

    void Start()
    {
        Destroy(gameObject, lifeTime); // Belirli bir süre sonra mermiyi yok et
    }

    void Update()
    {
        // Mermiyi ileri doðru hareket ettir
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Çarptýðýnda mermiyi yok et
        Destroy(gameObject);
    }
}
