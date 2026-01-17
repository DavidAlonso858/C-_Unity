using System.Collections;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    Camera cam;

    [SerializeField] private LayerMask layerGround, layerShoot;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float cadency;
    [SerializeField] AudioClip clipShoot;
    AudioSource audioS; // la fuente de audio del jugador a la cual le asignaremos los clips
    LineRenderer line;
    Light lightShoot;
    bool canshoot = true;

    private void Awake()
    {
        cam = Camera.main;
        lightShoot = shootPoint.GetComponent<Light>();
        line = shootPoint.GetComponent<LineRenderer>();
        audioS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 100, layerGround))
        {
            transform.LookAt(hit.point);
        }

        if (Input.GetButton("Fire1") && canshoot)
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        audioS.clip = clipShoot;
        audioS.Play();
        canshoot = false;
        lightShoot.enabled = true;
        line.SetPosition(0, shootPoint.position);
        if (Physics.Raycast(shootPoint.position, shootPoint.forward, out RaycastHit hit, 20, layerShoot))
        {
            line.SetPosition(1, hit.point);
            if (hit.transform.GetComponent<Enemy>())
            {
                hit.transform.GetComponent<Enemy>().GetDamage();
            }
        }
        else
        {
            line.SetPosition(1, shootPoint.position + shootPoint.forward * 20);

        }
        line.enabled = true;
        yield return new WaitForSeconds(0.05f);
        line.enabled = false;
        lightShoot.enabled = false;

        yield return new WaitForSeconds(cadency - 0.05f);
        canshoot = true;
    }
}
