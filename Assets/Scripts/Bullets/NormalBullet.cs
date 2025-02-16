using UnityEngine;

public class NormalBullet : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    public GameStart gameStart;

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Boss"))
        {
            gameStart.winGame();
            Destroy(gameObject);
        }
        else if (!collision.CompareTag("Player") && !collision.CompareTag("DarkArea"))
        {
            Destroy(gameObject);
        }
    }
}