using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;       // Pr�dko�� poruszania si�
    public float rotationSpeed = 500f; // Pr�dko�� obracania si�
    public float gravity = -9.81f;    // Si�a grawitacji
    public float jumpHeight = 2f;     // Wysoko�� skoku

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Sprawd�, czy gracz jest na ziemi
        isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Lekko przyci�gaj gracza do ziemi
        }

        // Pobierz input od gracza
        float moveX = Input.GetAxis("Horizontal"); // Lewo/Prawo (A/D)
        float moveZ = Input.GetAxis("Vertical");   // Prz�d/Ty� (W/S)

        // Oblicz kierunek ruchu
        Vector3 moveDirection = transform.right * moveX + transform.forward * moveZ;

        // Poruszaj graczem
        controller.Move(moveDirection * moveSpeed * Time.deltaTime);

        // Skok
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Grawitacja
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // Obr�t gracza w kierunku ruchu
        if (moveDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
}