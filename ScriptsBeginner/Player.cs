using UnityEngine;

public class Player : MonoBehaviour
{

    [Header("Player Speed")]
    [SerializeField]
    float speed, speedRotation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        // en cada frame mueve el objeto hacia adelante o hacia atrás segun el objeto Rigidbody
        // Time.deltaTime tiempo que ha durado el ultimo frame
        GetComponent<Rigidbody>().linearVelocity =
        transform.forward * Time.deltaTime * Input.GetAxis("Vertical") * speed;

        // Vector3 usando el eje Y
        transform.Rotate(Vector3.up * Time.deltaTime * Input.GetAxis("Horizontal") * speedRotation);
        
    }
}
