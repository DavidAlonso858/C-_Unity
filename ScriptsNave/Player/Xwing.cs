using UnityEngine;

public class Xwing : MonoBehaviour
{
    public float speed;
    public float turnSpeed;

    [SerializeField]
    private GameObject bulletPrefab; // prefab de la bala

    [SerializeField]
    private Transform[] posRotBullet;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        Cursor.lockState = CursorLockMode.Locked; // Bloquear el cursor en la pantalla
    }

    // Update is called once per frame
    private void Update()
    {
        MovementXwing();
        TurningXwing();
        Attack();
    }

    private void MovementXwing()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(h, 0, v);
        transform.Translate(direction.normalized * speed * Time.deltaTime);
    }

    private void TurningXwing()
    {
        float xMouse = Input.GetAxis("Mouse X");
        float yMouse = Input.GetAxis("Mouse Y");

        // el - en el ymouse para mover el cursor hacia arriba
        Vector3 rotation = new Vector3(-yMouse, xMouse, 0);
        transform.Rotate(rotation.normalized * turnSpeed * Time.deltaTime);
    }

    private void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            audioSource.Play(); // Reproduce el sonido del disparo

            for (int i = 0; i < posRotBullet.Length; i++)
            {
                Instantiate(bulletPrefab, posRotBullet[i].position, posRotBullet[i].rotation);

            }

        }

    }
}