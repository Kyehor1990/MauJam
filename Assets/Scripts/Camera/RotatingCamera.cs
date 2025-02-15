using UnityEngine;

public class RotatingCamera : MonoBehaviour
{
    public float rotationSpeed = 10f; // Kamera dönüş hızı
    public float maxAngle = 45f; // Maksimum dönüş açısı
    private float currentAngle = 0f; // Mevcut dönüş açısı
    private int direction = 1; // Dönüş yönü (1: sağa, -1: sola)

    void Update()
    {
        // Kamerayı döndür
        float rotationAmount = rotationSpeed * Time.deltaTime * direction;
        transform.Rotate(0, 0, rotationAmount);

        // Mevcut dönüş açısını güncelle
        currentAngle += rotationAmount;

        // Maksimum açıya ulaşıldığında yönü tersine çevir
        if (Mathf.Abs(currentAngle) >= maxAngle)
        {
            direction *= -1; // Yönü tersine çevir
            currentAngle = Mathf.Clamp(currentAngle, -maxAngle, maxAngle); // Açıyı sınırla
        }
    }
}