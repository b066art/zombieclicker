using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _zombieSpawner;
    [SerializeField] private GameObject _boosters;
    [SerializeField] private GameObject _scoreBar;
    [SerializeField] private GameObject _zombieCounter;
    [SerializeField] private GameObject _highscores;
    [SerializeField] private Text _highscoreText;
    [SerializeField] private AudioSource bGSound;
    [SerializeField] private AudioSource buttonSound;
    [SerializeField] private AudioSource gameOverSound;

    private int _highscore = 0;

    private void Start()
    {
        _camera.GetComponent<CameraMove>().enabled = false;
        _player.GetComponent<TargetClicker>().enabled = false;
        _zombieSpawner.GetComponent<ZombieSpawner>().enabled = false;

        bGSound.Stop();
        gameOverSound.Play();
        _highscore = _scoreBar.GetComponent<Score>()._score;
        _highscoreText.text = _highscore.ToString("000000");

        _highscores.GetComponent<Highscores>().NewRecord(_highscore);

        List<GameObject> zombies = _zombieCounter.GetComponent<ZombieCounter>().zombiesList;

        foreach (GameObject zombie in zombies)
        {
            Destroy(zombie);
        }

        _boosters.SetActive(false);
        _scoreBar.SetActive(false);
        _zombieCounter.SetActive(false);

        Time.timeScale = 0;
    }

    public void ResetButton()
    {
        gameOverSound.Stop();
        SceneManager.LoadScene("Main");
        Time.timeScale = 1;
        buttonSound.Play();
    }
}
