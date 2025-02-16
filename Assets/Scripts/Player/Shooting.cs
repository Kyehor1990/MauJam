using System;
using UnityEngine;
using TMPro;

public class Shooting : MonoBehaviour
{
    [SerializeField] GameObject normalBulletPrefab;
    [SerializeField] GameObject darkBulletPrefab;
    [SerializeField] Transform gunPosition;
    [SerializeField] float bulletSpeed = 10f;

    [SerializeField] public int NbulletCount = 3;
    [SerializeField] public int DbulletCount = 3;
    public TextMeshProUGUI bullet,blueBullet;
    
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Update()
    {
        bullet.text = NbulletCount.ToString();
        blueBullet.text = DbulletCount.ToString();
        if (Time.timeScale == 1f)
        {
            if (Input.GetMouseButtonDown(0) && NbulletCount > 0)
            {
                audioManager.PlaySFX(audioManager.shoot);
                Shoot(normalBulletPrefab);
                NbulletCount--;
            }

            if (Input.GetMouseButtonDown(1) && DbulletCount > 0)
            {
                audioManager.PlaySFX(audioManager.shoot);
                Shoot(darkBulletPrefab);
                DbulletCount--;
            }
        }
    }

    void Shoot(GameObject bulletPrefab)
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - (Vector2)gunPosition.position).normalized;

        // Instantiate the bullet
        GameObject bullet = Instantiate(bulletPrefab, gunPosition.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

        if (bulletPrefab == darkBulletPrefab)
        {
            DarkBullet darkBullet = bullet.GetComponent<DarkBullet>();
            if (darkBullet != null)
            {
                darkBullet.SetTargetPosition(mousePosition);
            }
        }
        else
        {
            // For normal bullets, set velocity
            bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        }

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}