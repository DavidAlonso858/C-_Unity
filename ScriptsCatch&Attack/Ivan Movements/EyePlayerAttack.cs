using UnityEngine;

public class EyePlayerAttack : MonoBehaviour
{
    public GameObject eyeBulletPrefab;
    public Transform eyeBulletPos;

    void Awake()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // click izquierdo
        {
            Instantiate(eyeBulletPrefab, eyeBulletPos.position, eyeBulletPos.rotation);
        }
    }
}