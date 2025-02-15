using UnityEngine;

public class WeaponAim : MonoBehaviour
{
    public Camera mainCamera;
    public Transform player;

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = mainCamera.ScreenToWorldPoint(mousePos);

        Vector3 direction = mousePos - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        
        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        if (player.localScale.x < 0)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, angle + 180f);
        }
    }
}