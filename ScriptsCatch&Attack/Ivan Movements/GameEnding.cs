using UnityEngine;

public class GameEnding : MonoBehaviour
{
    
    public GameObject caughtImage;
    public GameObject winImage;

    private void Awake()
    {

    }

    // Update is called once per frame
    private void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            winImage.SetActive(true);
        }
    }

    // Este metodo va a ser llamado desde el script
    public void CaughtPlayer()
    {
        caughtImage.SetActive(true);
    }

}
