using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // recordatorio de que static hace que siempre pertenezca a la memoria y no a una instancia 
    public static GameManager instance;
    [SerializeField] TextMeshProUGUI countDownText, waveText, EnemiesText;

    int wave = 0;
    Spawner[] spawner;
    int maxEnemyWave, currentEnemies;

    [SerializeField] GameObject panelGameOver, panelPause;

    [SerializeField] AudioMixer audioMixer;
    private void Awake()
    {
        panelGameOver.SetActive(false);
        panelPause.SetActive(false);
        // la instancia es este propio script
        instance = this;

        GameObject[] objectsSpawn = GameObject.FindGameObjectsWithTag("Spawner");
        spawner = new Spawner[objectsSpawn.Length];
        for (int i = 0; i < objectsSpawn.Length; i++)
        {
            spawner[i] = objectsSpawn[i].GetComponent<Spawner>();
        }
        Time.timeScale = 1f;
        StartCoroutine(NewWave());

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Space))
        {
            Pause();
        }
    }

    IEnumerator NewWave()
    {
        wave++;
        countDownText.gameObject.SetActive(true);
        for (int i = 4; i >= 0; i--)
        {
            if (i == 4) countDownText.text = "NEW WAVE";
            else if (i == 0) countDownText.text = "GO!";
            else countDownText.text = i.ToString();

            for (int j = 0; j < 10; j++)
            {
                countDownText.transform.localScale = Vector3.one * 0.5f + Vector3.one * 0.05f * j;
                yield return new WaitForSeconds(0.1f);
            }
        }

        countDownText.gameObject.SetActive(false);
        // TERMINA LA CUENTA ATRAS
        maxEnemyWave = (2 + wave) * spawner.Length;
        currentEnemies = maxEnemyWave;
        waveText.text = "WAVE " + wave;
        EnemiesText.text = "ENEMIES: " + maxEnemyWave + "/" + maxEnemyWave;

        for (int i = 0; i < spawner.Length; i++)
        {
            spawner[i].StartSpawn(2 + wave, 0.5f + (1.5f / wave));
        }
    }

    public void EnemyDeath()
    {
        currentEnemies--;
        EnemiesText.text = "ENEMIES " + currentEnemies + "/" + maxEnemyWave;

        // si no quedan enemigos en la oleada empezamos una nueva;
        if (currentEnemies <= 0)
        {
            StartCoroutine(NewWave());
        }
    }

    public void GameOver()
    {
        panelGameOver.SetActive(true);
        int score = 0;
        for (int i = 0; i < wave; i++)
        {
            score += (i + 2) * spawner.Length;
        }
        score += (maxEnemyWave - currentEnemies);
        panelGameOver.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "Score: " + score;

        int maxScore = PlayerPrefs.GetInt("maxScore", 0);
        if (score > maxScore)
        {
            maxScore = score;

            PlayerPrefs.SetInt("maxScore", maxScore);
        }
        panelGameOver.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = "Max Score: " + maxScore;

    }
    public void Pause()
    {
        if (Time.timeScale > 0f)
        {
            panelPause.SetActive(true);
            Time.timeScale = 0f;

        }
        else
        {
            panelPause.SetActive(false);
            Time.timeScale = 1f;
            
        }
    }
    public void ResetScene()
    {
        // Pillo la escena vacia y recargo la actual con el indice
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ChangeVolumeMaster(float volume)
    {
        audioMixer.SetFloat("VolumeMaster", volume);
    }
    public void ChangeVolumeMusic(float volume)
    {
        audioMixer.SetFloat("VolumeMusic", volume);
    }
    public void ChangeVolumeSFX(float volume)
    {
        audioMixer.SetFloat("VolumeSFX", volume);
    }

}
