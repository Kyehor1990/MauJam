using UnityEngine;
using System.Linq;

public class EnemySight : MonoBehaviour
{
    [SerializeField] float viewRadius = 5f;
    [SerializeField] float viewAngle = 90f;
    [SerializeField] LayerMask playerLayer;
    [SerializeField] LayerMask obstacleLayer;
    [SerializeField] LayerMask darkAreaLayer;

    private GameObject[] players;
    private GameObject[] deathPlayers;
    public GameStart gameStart;

    void Update()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        deathPlayers = GameObject.FindGameObjectsWithTag("DeathPlayer");
        
        foreach (var player in players.Concat(deathPlayers))
        {
            if (CanSeePlayer(player.transform))
            {
                if (IsPlayerHidden(player.transform))
                {
                    Debug.Log("Player is hidden. Enemy cannot see the player.");
                }
                else
                {
                    Debug.Log("Player is seen! Game Over.");
                    GameOver();
                    return;
                }
            }
        }
    }

    bool CanSeePlayer(Transform target)
    {
        Vector2 directionToTarget = (target.position - transform.position).normalized;
        
        if (Vector2.Angle(transform.right, directionToTarget) < viewAngle / 2)
        {
            float distanceToTarget = Vector2.Distance(transform.position, target.position);

            if (distanceToTarget < viewRadius)
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, directionToTarget, distanceToTarget, obstacleLayer);
                if (hit.collider == null)
                {
                    return true;
                }
            }
        }
        return false;
    }

    bool IsPlayerHidden(Transform target)
    {
        Collider2D[] darkAreas = Physics2D.OverlapCircleAll(target.position, 0.1f, darkAreaLayer);
        if (darkAreas.Length > 0)
        {
            return true;
        }

        Vector2 directionToTarget = (target.position - transform.position).normalized;
        float distanceToTarget = Vector2.Distance(transform.position, target.position);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, directionToTarget, distanceToTarget, darkAreaLayer);
        return hit.collider != null;
    }

    void GameOver()
    {
        gameStart.loseGame();
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