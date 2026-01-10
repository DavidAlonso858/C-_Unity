using System;
using UnityEditor.Callbacks;
using UnityEngine;

public class IvanPlayerMovement : MonoBehaviour
{
    [Header("Speed Player")]
    [SerializeField]
    private float speed;
    [SerializeField]
    private float turnSpeed;

    private float vertical;
    private float horizontal;

    private Animator animacion;
    private Vector3 direction;
    private Boolean walking;

    private Rigidbody rb;
    private AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        // accedemos al componente Animator que lleva el gameObject 
        animacion = GetComponent<Animator>();

        // accedemos al componente Rigidbody que lleva el gameObject
        rb = GetComponent<Rigidbody>();

        // accedemos al componente AudioSource que lleva el gameObject
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void Update()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        // le doy valor a la variable direction para que me guarde los inputs
        direction.Set(horizontal, 0, vertical);

        // Normalizar el vector para que todos los movimientos tengan la misma velocidad
        direction.Normalize();

        // transform.Translate(direction * speed * Time.deltaTime);

        Animation();
        AudioPlayer();
    }

    // Se ejecuta cada 0.2 segundos este metodo
    private void FixedUpdate()
    {
        // movimiento del personaje por fisicas
        rb.MovePosition(rb.position + (direction * speed * Time.deltaTime));
        Rotation();
    }

    private void Rotation()
    {
        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, direction, turnSpeed * Time.deltaTime, 0);

        Quaternion rotation = Quaternion.LookRotation(desiredForward);
        rb.MoveRotation(rotation);
    }

    private void AudioPlayer()
    {
        if (vertical != 0 || horizontal != 0)
        {
            if (audioSource.isPlaying == false) // si no se está reproduciendo el audio
            {
                audioSource.Play();
            }
        }
        else // no se está moviendo
        {
            audioSource.Stop();
        }
    }
    private void Animation()
    {
        // si vertical esta en 0 estara en la animacion de idle
        // si vertical es mayor que 0 estara en la animacion de isWalking
        if (vertical != 0 || horizontal != 0)
        {
            // isWalking es el nombre del parametro booleano
            // creado en Unity en la pestaña Windows/Animation/Animator
            animacion.SetBool("isWalking", true);
        }
        else
        {
            animacion.SetBool("isWalking", false);
        }
    }
}
