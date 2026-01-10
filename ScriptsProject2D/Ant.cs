using UnityEngine;

public class Ant : MonoBehaviour
{
    [SerializeField]
    // El array con los puntos entre los que quiero
    // que se mueva la hormiga
    private Transform[] pointsGameObjects;

    // Array Auxiliar obviando el eje Z
    private Vector2[] pointsXY;
    // Posicion siguiente a la que se tiene que mover la hormiga
    private Vector3 posToGo;

    [Header("Ant Movement")]
    private int currentSpeed; // Velocidad de la hormiga
    private int index; // Para movernos entre el indice del array

    [Header("Follow Player")]
    [SerializeField]
    private float distanceToPlayer;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    // Aumentar la velocidd de la hormiga
    private int speedAttack;
    [SerializeField]
    // Aumentar la velocidad de la animacion
    private float speedAnimation;
    [SerializeField]
    // Velocidad normal de la hormiga cuando camina
    private int speedWalking;

    private Animator anim;
    private SpriteRenderer spriteRenderer;


    private void Awake()
    {
        currentSpeed = speedWalking;
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // le paso el tamanio del array en unity con el SerializeField
        // Quiero que el auxiliar sea igual de grande que el original
        pointsXY = new Vector2[pointsGameObjects.Length];
        for (int i = 0; i < pointsGameObjects.Length; i++)
        {
            // la posicion Z la dejara en 0 
            pointsXY[i] = pointsGameObjects[i].position;
        }

        //Al primer lugar que quiero que vaya la hormig, es al que se encuentra
        // guardado en el primer cajon de mi array auxiliar
        posToGo = pointsXY[0];
    }

    // Update is called once per frame
    private void Update()
    {
        // Calculamos con el metodo Distance la distancia entre la hormiga y el player
        // Y si la distancia es menor o igual a la variable distanceToPlayer pues ataca
        if (Vector2.Distance(transform.position, player.transform.position) <= distanceToPlayer)
        {
            AttackPlayer();
        }
        // Si la distancia entre player y hormiga es mayor a distanceToPlayer
        // la hormiga seguiria su camino
        else
        {
            ChangeTargetPos();
        }
        transform.position = Vector3.MoveTowards(transform.position, posToGo,
        currentSpeed * Time.deltaTime);
        Flip();
    }

    private void AttackPlayer()
    {
        currentSpeed = speedAttack;
        anim.speed = speedAnimation;
        // La altura en Y se conserva con la que tenemos guardadas en el array
        // Pero en X ahora quiero que se mueva a la posicion del player en X
        posToGo = new Vector2(player.transform.position.x, posToGo.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // para que solo me quite damage si estoy en el suelo
        if (collision.collider.CompareTag("Player") && collision.collider.GetComponent<SquirrelMovement>().isGrounded)
        {
            collision.collider.GetComponent<PlayerHealth>().TakeDamage(35);
        }
    }


    private void ChangeTargetPos()
    {
        currentSpeed = speedWalking;
        // uno equivale a los samples  
        anim.speed = 1;
        // Si la hormiga ha llegado al lugar de destino
        if (transform.position == posToGo)
        {
            // Cuando la hormiga llegue a la ultima posicion guardada en el array
            // pues que vuelve a la posicion 0
            if (index == pointsXY.Length - 1)
            {
                index = 0;
            }
            else
            {
                // Avanzo a la siguiente posicion
                index++;
            }

            //Actualizando el posToGo en funcion de donde nos encontremos en el index
            posToGo = pointsXY[index];

        }
    }

    private void Flip()
    {
        // la hormiga va hacia la derecha al ser un numero mayor que 0
        if (posToGo.x > transform.position.x)
        {
            spriteRenderer.flipX = true;
        }
        // Si la hormiga se mueve hacia la izquierda desmarco el flipX
        else if (posToGo.x < transform.position.x)
        {
            spriteRenderer.flipX = false;

        }
    }

}
