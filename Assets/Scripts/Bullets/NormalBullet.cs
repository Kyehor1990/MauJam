using UnityEngine;

public class NormalBullet : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    
    AudioManager audioManager;
    
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            audioManager.PlaySFX(audioManager.aydınlık);
            Destroy(gameObject);
        }
        else if (!collision.CompareTag("Player") && !collision.CompareTag("DarkArea"))
        {
            audioManager.PlaySFX(audioManager.aydınlık);
            Destroy(gameObject);
        }
    }
}