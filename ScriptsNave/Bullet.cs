using UnityEngine;
using UnityEngine.UIElements;
public class Bullet : MonoBehaviour
{
    [SerializeField]
    private int speed;

    private void Awake()
    {
        Destroy(gameObject, 0.8f);

    }

    // Update is called once per frame
    void Update()
    {
        // En el eje Z a esa velocidad quiero que se mueva la bala
        transform.Translate(speed * Vector3.forward * Time.deltaTime);
    }

}
