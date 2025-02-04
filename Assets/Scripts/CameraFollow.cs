using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;  // Przypisz obiekt gracza w Inspectorze
    public float smoothSpeed = 5f; // P�ynno�� ruchu kamery
    public Vector3 offset = new Vector3(0, 2, -4); // Pozycja kamery wzgl�dem gracza

    void LateUpdate()
    {
        // Oblicz pozycj� docelow�
        Vector3 desiredPosition = player.position + player.transform.rotation * offset;

        // P�ynne przej�cie kamery
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // Obr�t kamery w kierunku gracza
        transform.rotation = Quaternion.Lerp(transform.rotation, player.rotation, smoothSpeed * Time.deltaTime);
    }
}
