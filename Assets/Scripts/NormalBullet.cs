using UnityEngine;

public class NormalBullet : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 1;

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            //collision.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject);
        }
        else if (!collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}