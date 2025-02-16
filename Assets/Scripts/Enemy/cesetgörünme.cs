using UnityEngine;

public class ceset : MonoBehaviour
{
    [SerializeField] float viewRadius = 5f;
    [SerializeField] float viewAngle = 90f; // Angle of the enemy's line of sight (in degrees)
    [SerializeField] LayerMask cesetLayer; // Layer for the player
    [SerializeField] LayerMask obstacleLayer; // Layer for obstacles (e.g., walls, dark areas)
    [SerializeField] LayerMask darkAreaLayer; // Layer for dark areas

    private Transform player;

    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("ceset").transform;
    }

    void Update()
    {
        player = GameObject.FindGameObjectWithTag("ceset").transform;
        if (CanSeePlayer())
        {
            if (IsPlayerHidden())
            {
                Debug.Log("Player is hidden. Enemy cannot see the player.");
            }
            else
            {
                Debug.Log("Player is seen! Game Over.");
                GameOver();
            }
        }
    }

    bool CanSeePlayer()
    {
        Vector2 directionToPlayer = (player.position - transform.position).normalized;

        // Check if the player is within the view angle
        if (Vector2.Angle(transform.right, directionToPlayer) < viewAngle / 2)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);

            // Check if the player is within the view radius
            if (distanceToPlayer < viewRadius)
            {
                // Check if there are no obstacles between the enemy and the player
                RaycastHit2D hit = Physics2D.Raycast(transform.position, directionToPlayer, distanceToPlayer,
                    obstacleLayer);
                if (hit.collider == null)
                {
                    return true;
                }
            }
        }

        return false;
    }

    bool IsPlayerHidden()
    {
        Collider2D[] darkAreas = Physics2D.OverlapCircleAll(player.position, 0.1f, darkAreaLayer);
        if (darkAreas.Length > 0)
        {
            Debug.Log("Player is dark area.");
            return true;
        }

        Vector2 directionToPlayer = (player.position - transform.position).normalized;
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, directionToPlayer, distanceToPlayer, darkAreaLayer);
        if (hit.collider != null)
        {
            return true;
        }

        return false;
    }

    void GameOver()
    {
        Debug.Log("Game Over!");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, viewRadius);

        Vector3 viewAngleA = DirFromAngle(-viewAngle / 2, false);
        Vector3 viewAngleB = DirFromAngle(viewAngle / 2, false);
        Gizmos.DrawLine(transform.position, transform.position + viewAngleA * viewRadius);
        Gizmos.DrawLine(transform.position, transform.position + viewAngleB * viewRadius);
    }

    Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.z;
        }

        return new Vector3(Mathf.Cos(angleInDegrees * Mathf.Deg2Rad), Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0);
    }
}
