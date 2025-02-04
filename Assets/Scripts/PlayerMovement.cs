using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;       // Prêdkoœæ poruszania siê
    public float rotationSpeed = 500f; // Prêdkoœæ obracania siê
    public float gravity = -9.81f;    // Si³a grawitacji
    public float jumpHeight = 2f;     // Wysokoœæ skoku

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // SprawdŸ, czy gracz jest na ziemi
        isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Lekko przyci¹gaj gracza do ziemi
        }

        // Pobierz input od gracza
        float moveX = Input.GetAxis("Horizontal"); // Lewo/Prawo (A/D)
        float moveZ = Input.GetAxis("Vertical");   // Przód/Ty³ (W/S)

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

        // Obrót gracza w kierunku ruchu
        if (moveDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
}