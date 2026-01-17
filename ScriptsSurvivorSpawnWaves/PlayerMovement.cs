using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;

    Rigidbody rb;

    private Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {

    }

    // movimiento para las fisicas por eso uso FixedUpdate
    private void FixedUpdate()
    {
        if (rb != null)
        {
            // .normalized * speed para regular la velocidad en diagonal
            rb.linearVelocity = (Vector3.forward * Input.GetAxis("Vertical")
            + Vector3.right * Input.GetAxis("Horizontal")).normalized * speed;

        }

        // animator = GetComponent<Animator>();
        // esa forma valdria pero mejor con el puntero a la variable creada en el animator
        animator.SetFloat("velocity", rb.linearVelocity.magnitude);

    }

}
