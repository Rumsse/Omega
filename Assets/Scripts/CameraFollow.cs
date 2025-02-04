using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;  // Przypisz obiekt gracza w Inspectorze
    public float smoothSpeed = 5f; // P³ynnoœæ ruchu kamery
    public Vector3 offset = new Vector3(0, 2, -4); // Pozycja kamery wzglêdem gracza

    void LateUpdate()
    {
        // Oblicz pozycjê docelow¹
        Vector3 desiredPosition = player.position + player.transform.rotation * offset;

        // P³ynne przejœcie kamery
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // Obrót kamery w kierunku gracza
        transform.rotation = Quaternion.Lerp(transform.rotation, player.rotation, smoothSpeed * Time.deltaTime);
    }
}
