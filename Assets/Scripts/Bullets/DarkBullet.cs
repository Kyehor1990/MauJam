using UnityEngine;

public class DarkBullet : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] GameObject darkAreaPrefab;
    private Vector2 targetPosition;
    
    AudioManager audioManager;
    
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

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
        if (!collision.CompareTag("Player") && !collision.CompareTag("DarkArea"))
        {
            audioManager.PlaySFX(audioManager.karanlık);
            Instantiate(darkAreaPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}