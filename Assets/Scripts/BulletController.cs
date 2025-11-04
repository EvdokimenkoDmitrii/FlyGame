using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 1;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Bullet collided with: " + collision.gameObject.name + " | Tag: " + collision.gameObject.tag);

        // Проверяем, попали ли в игрока
        if (collision.CompareTag("Player"))
        {
            // Пытаемся получить компонент PlayerController1
            PlayerController1 player1 = collision.GetComponent<PlayerController1>();
            if (player1 != null)
            {
                player1.TakeDamage(damage);
                Debug.Log("Bullet hit Player1!");
            }

            // Пытаемся получить компонент PlayerController2
            PlayerController2 player2 = collision.GetComponent<PlayerController2>();
            if (player2 != null)
            {
                player2.TakeDamage(damage);
                Debug.Log("Bullet hit Player2!");
            }

            Destroy(gameObject); // Уничтожаем пулю
        }

        // Уничтожаем пулю при столкновении со стеной
        if (collision.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}