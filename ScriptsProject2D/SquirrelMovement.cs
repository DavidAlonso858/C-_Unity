using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class SquirrelMovement : MonoBehaviour
{
    [Header("Squirrel Movement")]
    [SerializeField]
    // Velocidad maxima
    private float speed;

    [SerializeField]
    // Tiempo que vamos a tardar en llegar a la velocidad que queremos
    private float smoothTime;

    [Header("Squirrel Jump")]
    [SerializeField]
    // fuerza que tendra el salto
    private float jumpForce;

    // ¿He pulsado el boton de salto?
    private bool jumpPressed;

    [Header("Raycast")]
    [SerializeField]
    // Punto de origen del raycast (a los pies de la ardilla)
    private Transform groundCheck;

    [SerializeField]
    // Capa del suelo
    private LayerMask groundLayer;

    [SerializeField]
    // Longitud del raycast
    private float rayLenght;

    [SerializeField]
    // Variable donde guardaremos si el raycast toca el suelo o no
    public bool isGrounded;


    private Rigidbody2D rb;
    // Direccion en la que se movera el personaje una vez aplicada la velocidad
    Vector2 targetVelocity;

    // Variable que necesita Unity, Velocidad de suavizado
    Vector2 dampVelocity;

    SpriteRenderer spriteRenderer;

    Animator animator;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        // Vamos a saltar con la barra espaciadora y tocamos el suelo
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            jumpPressed = true;

        }
        // Llamamos al movimiento
        InputMovement();

        // Aunque use rb lo usamos en Update 
        ChangeGravity();

        // Raycast al que le indicamos su origen, direccion, longitud y capa.
        // Todas variables creadas menos direccion que el Vector2 ya lo podemos usar para eso
        isGrounded = Physics2D.Raycast(groundCheck.position, Vector2.down, rayLenght,
         groundLayer);

        // Dibujamos el rayo para verlo en escena y comprobar que funciona correctamente
        Debug.DrawRay(groundCheck.position, Vector2.down * rayLenght, Color.green);

    }

    private void FixedUpdate()
    {
        // Llamamos al metodo salto mientras hayamos pulsado la barra
        if (jumpPressed == true)
        {
            Jump();
        }

        // 1º Parametro: Es el valor actual de la ardilla (su velocidad) Donde estoy
        // 2º Parametro: Es el valor al que quiero llegar (targetVelocity) A donde quiero ir
        // 3º Parametro: Es una referencia a la variable que usa Unity para hacer el suavizado
        // 4º Parametro: Es el tiempo que quiero tardar en llegar a la velocidad objetivo

        // modificamos la velocidad de la ardilla a partir de su rigidBody
        rb.linearVelocity = Vector2.SmoothDamp(rb.linearVelocity, targetVelocity,
        ref dampVelocity, smoothTime);
    }

    private void InputMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        // float vertical = Input.GetAxis("Vertical");

        // rb.linearVelocityY es un get que pilla velocidad en Y 
        // por si salta tambien tener registrado la velocidad
        targetVelocity = new Vector2(horizontal * speed, rb.linearVelocityY);
        Flip(horizontal);
        Animating(horizontal);
    }

    private void AttackEnemy(GameObject enemy)
    {
        // Si estoy tocando el suelo la ardilla no puede atacar al enemigo
        if (isGrounded) return;

        rb.AddForce(Vector2.up * jumpForce);
        // Tendriamos que establecer la animacion de la muerte de la hormiga
        // Accedo al componente Animator del enemigo que se le ha pasado como parametro
        // SetTrigger() con nombre variable que he creado en el panel Animator de Unity
        enemy.GetComponent<Animator>().SetTrigger("Death");
        // Destruimos a la hormiga
        Destroy(enemy, 0.3f);
    }

    // Vamos a parar el movimiento de la ardilla
    public void ResetVelocity()
    {
        targetVelocity = Vector2.zero;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Si los dos collider chocan y si el que choca tiene el tag de "Ant" pues ataca
        if (collision.collider.CompareTag("Ant"))
        {
            AttackEnemy(collision.gameObject);
        }
    }

    private void ChangeGravity()
    {
        // Si la ardilla esta cayendo aumentamos un poco el gravityScale
        if (rb.linearVelocityY < 0)
        {
            rb.gravityScale = 2;
        }
        else
        {
            rb.gravityScale = 1;
        }
    }

    // Gira la ardilla de izquierda a derecha
    private void Flip(float horizontal)
    {
        if (horizontal > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (horizontal < 0)
        {
            spriteRenderer.flipX = true;
        }
    }

    // establecer la animacion con la variable isRunning creada en el Animator de Unity
    private void Animating(float horizontal)
    {
        if (horizontal != 0)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        // mientras no este tocando el suelo quiero que haga la animación de saltar
        animator.SetBool("isJumping", !isGrounded);

    }

    private void Jump()
    {
        jumpPressed = false;
        rb.AddForce(Vector2.up * jumpForce);

    }
}
