using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    // la camara tiene que seguir al player
    private Transform player;

    // Distancia inicial entre camara y player.
    // Usamos Vector3 porque existe el eje Z aunque estemos en un juego 2D
    private Vector3 offset;

    [SerializeField]
    // El Tiempo que vamos a tardar en llegar a la velocidad que queramos
    private float smoothTargetTime;

    // Variable que necesita Unity, Velocidad de suavizado
    Vector3 dampVelocity;

    private void Awake()
    {
        offset = transform.position - player.position;
    }

    // Update is called once per frame
    private void Update()
    {
        // Donde estamos (la posicion de la camara)
        // Hacia donde vamos (la posicion del player + offset)
        // 
        transform.position = Vector3.SmoothDamp(transform.position, player.position + offset
        , ref dampVelocity, smoothTargetTime);
    }

}
