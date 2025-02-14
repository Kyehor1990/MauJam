using UnityEngine;

public class DarkBullet : MonoBehaviour
{
    public float speed = 10f;
    public GameObject darkAreaPrefab; // Prefab for the dark area
    private Vector2 targetPosition; // The position where the dark area will spawn

    public void SetTargetPosition(Vector2 position)
    {
        targetPosition = position;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        
        if ((Vector2)transform.position == targetPosition)
        {
            Instantiate(darkAreaPrefab, targetPosition, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        {
            Instantiate(darkAreaPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}