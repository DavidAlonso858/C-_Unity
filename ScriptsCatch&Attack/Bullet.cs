using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float force;

    // acedemos al componente Rigidbody
    private Rigidbody rb;

    void Awake()
    {
        // con el GetComponent accedemos a cualquier componente que lleve el gamObject
        rb = GetComponent<Rigidbody>();

        // force es la magnitud de la fuerza que aplicamos a la bala
        rb.AddForce(Vector3.up * force / 2);
        rb.AddForce(transform.forward * force); // transform.forward haciendo referencia al eje Z local de la esfera    ;

        // el gameObject se destruye a los 3s de ser instanciado o el tiempo que pongamos
        Destroy(gameObject, 3);
    }

    void Update()
    {

    }
}