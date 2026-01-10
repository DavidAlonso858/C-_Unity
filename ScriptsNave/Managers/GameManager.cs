using UnityEngine;
using UnityEngine.SceneManagement; // para manejar escenas

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject panelGameOver;

    [SerializeField]
    private EnemyManager enemyManager;

    private void Awake()
    {

    }

    private void Update()
    {

    }

    public void LoadSceneLeve()
    {
        // Cargar la escena tal cual la he llamado en el proyecto
        SceneManager.LoadScene("StarWars1");
    }

    public void GameOver()
    {
        // Activamos el panel de Game Over (debe estar desactivado al iniciar el juego)
        panelGameOver.SetActive(true);

        // desactivamos el enemy manager para que no siga generando enemigos
        enemyManager.enabled = false;
        
        // Libero al cursor para poder pulsar en los botones de la pantalla de muerte
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void Exit()
    {
        // Esto solo funcionara cuando tengamos la build de nuestro juego lista
        Application.Quit();
    }
}
