using UnityEngine;
using Unity.Cinemachine;

public class CameraMachineExample : MonoBehaviour
{
    [SerializeField]
    private CinemachineCamera wallCamera;

    private bool firstTime;

    void Awake()
    {
        firstTime = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall") && firstTime)
        {
            wallCamera.gameObject.SetActive(true);
            firstTime = false;
            Invoke(nameof(DesactivateCamera), 5);
        }
    }

    private void DesactivateCamera()
    {
        wallCamera.gameObject.SetActive(false);
    }

}
