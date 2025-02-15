using UnityEngine;

public class CameraFOV : MonoBehaviour
{
    public float viewRadius = 10f; // Kamera görüş yarıçapı
    [Range(0, 360)]
    public float viewAngle = 90f; // Kamera görüş açısı
    public LayerMask targetMask; // Oyuncunun layer'ı
    public LayerMask obstacleMask; // Engellerin layer'ı
    public GameObject player; // Oyuncu referansı

    private bool isGameOver = false;

    void Update()
    {
        if (!isGameOver)
        {
            CheckForPlayer();
        }
    }

    void CheckForPlayer()
    {
        // Oyuncuyu görüş alanı içinde mi diye kontrol et
        Collider2D[] targetsInViewRadius = Physics2D.OverlapCircleAll(transform.position, viewRadius, targetMask);

        foreach (Collider2D target in targetsInViewRadius)
        {
            if (target.gameObject == player)
            {
                Vector3 dirToTarget = (target.transform.position - transform.position).normalized;
                float angleToTarget = Vector3.Angle(transform.up, dirToTarget);

                // Oyuncu görüş açısı içinde mi?
                if (angleToTarget < viewAngle / 2)
                {
                    float dstToTarget = Vector3.Distance(transform.position, target.transform.position);

                    // Oyuncu ile kamera arasında engel var mı?
                    if (!Physics2D.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask))
                    {
                        // Oyuncu görüldü, oyunu bitir
                        GameOver();
                    }
                }
            }
        }
    }

    void GameOver()
    {
        isGameOver = true;
        Debug.Log("Oyun Bitti! Kamera seni gördü.");
        // Oyunu bitirme mantığını buraya ekleyebilirsiniz (örneğin, bir UI göstererek veya sahneyi yeniden yükleyerek).
    }

    void OnDrawGizmosSelected()
    {
        // Görüş alanını görselleştir (debug için)
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, viewRadius);

        Vector3 viewAngleA = DirFromAngle(-viewAngle / 2, false);
        Vector3 viewAngleB = DirFromAngle(viewAngle / 2, false);

        Gizmos.DrawLine(transform.position, transform.position + viewAngleA * viewRadius);
        Gizmos.DrawLine(transform.position, transform.position + viewAngleB * viewRadius);
    }

    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.z;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), Mathf.Cos(angleInDegrees * Mathf.Deg2Rad), 0);
    }
}