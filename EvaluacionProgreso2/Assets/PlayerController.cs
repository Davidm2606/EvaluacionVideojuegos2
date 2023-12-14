using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Configuración de velocidad de movimiento y giro
    public float forwardSpeed = 5f;
    public float rotationSpeed = 180f;

    // Variable para almacenar si se puede acelerar
    private bool canAccelerate = false;

    // Tiempo de espera antes de permitir acelerar (en segundos)
    public float accelerationDelay = 4f;

    // Tiempo cuando se permitirá acelerar
    private float accelerationStartTime;

    void Start()
    {
        // Inicializar el tiempo de inicio para la aceleración
        accelerationStartTime = Time.time + accelerationDelay;
    }

    void Update()
    {
        // Verificar si se puede acelerar y la barra espaciadora está presionada
        if (canAccelerate && Input.GetKeyDown(KeyCode.Space))
        {
            // Triplicar la velocidad
            forwardSpeed *= 3f;
            // Desactivar la capacidad de acelerar para evitar cambios continuos de velocidad
            canAccelerate = false;
        }

        // Mover al jugador automáticamente hacia adelante
        transform.Translate(Vector3.up * forwardSpeed * Time.deltaTime);

        // Obtener la dirección del giro desde las teclas de entrada
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calcular el ángulo de rotación
        float rotation = horizontalInput * rotationSpeed * Time.deltaTime;

        // Girar al jugador en la dirección de las teclas de entrada
        transform.Rotate(Vector3.forward, rotation);

        // Verificar si ha pasado el tiempo de espera para permitir acelerar
        if (!canAccelerate && Time.time >= accelerationStartTime)
        {
            // Activar la capacidad de acelerar
            canAccelerate = true;
        }
    }

    // Método llamado cuando se produce una colisión
    void OnTriggerEnter2D(Collider2D other)
    {
        // Verificar si la colisión es con el objeto de la meta
        if (other.CompareTag("Meta"))
        {
            // Mostrar mensaje de completar la carrera (puedes ajustar esto según tus necesidades)
            Debug.Log("¡Completaste la carrera!");

            // Puedes cargar otra escena aquí o realizar otras acciones según tus necesidades
            // Por ejemplo, reiniciar el nivel actual
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}



