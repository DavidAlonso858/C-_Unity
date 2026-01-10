using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    // Velocidad del movimiento
    private float moveSpeed = 1f;

    [SerializeField]
    // Velocidad del giro/rotacion
    private float turnSpeed = 90f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {

        // MovePlayer();
        MovePlayerAxis();
        TurningAxis();
    }

    private void MovePlayer()
    {
        // GetKey() busca el boton que yo quiera establecido dentro del parentesis
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            // Desde el componente transform, accedo al metodo Translate que me permitira moverme
            // Entre parentesis establezco la direccion y la velocidad al moverme
            // Vector3 accede al contenedor de las 3 variables de posicion (x, y, z)
            // Time.deltaTime hace que el movimiento sea independiente de los frames por segundo
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            // Tambien se puede poner -Vector3.forward 
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            // Usamos el Eje Y (up) para que rote sobre si mismo
            // Si usamos el Eje X daria una voltereta
            // Niego la velocidad de giro (sentido antihorario) para que gire a la izquierda
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            // Usamos el Eje Y (up) para que rote sobre si mismo a la derecha 
            // Si usamos el Eje X daria una voltereta
            // Positivo la velocidad de giro (sentido horario) para que gire a la derecha
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
        }
    }

    // Movemos en el Eje X y Z para avanzar y retroceder
    private void MovePlayerAxis()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical);

        transform.Translate(direction.normalized * moveSpeed * Time.deltaTime);
    }

    // Movemos en el Eje Y para girarla
    private void TurningAxis()
    {
        float xMouse = Input.GetAxis("Mouse X");
        float yMouse = Input.GetAxis("Mouse Y");
        Vector3 rotation = new Vector3(xMouse, yMouse, 0);

        transform.Rotate(rotation * turnSpeed * Time.deltaTime);
    }
}
