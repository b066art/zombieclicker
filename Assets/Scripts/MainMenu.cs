using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _zombieSpawner;
    [SerializeField] private GameObject _boosters;
    [SerializeField] private GameObject _scoreBar;
    [SerializeField] private GameObject _zombieCounter;
    [SerializeField] private GameObject _buttons;
    [SerializeField] private GameObject _exitButton;
    [SerializeField] private GameObject _backButton;
    [SerializeField] private GameObject _creditsText;
    [SerializeField] private GameObject _highscoresText;
    [SerializeField] private AudioSource bGMusic;
    [SerializeField] private AudioSource bGSound;
    [SerializeField] private AudioSource buttonSound;

    public void PlayButton()
    {
        buttonSound.Play();
        _camera.GetComponent<CameraMove>().enabled = true;
        _player.GetComponent<TargetClicker>().enabled = true;
        _zombieSpawner.GetComponent<ZombieSpawner>().enabled = true;
        _boosters.SetActive(true);
        _scoreBar.SetActive(true);
        _zombieCounter.SetActive(true);
        gameObject.SetActive(false);
        bGMusic.Stop();
        bGSound.Play();
    }

    public void HighscoresButton()
    {
        buttonSound.Play();
        _buttons.SetActive(false);
        _exitButton.SetActive(false);
        _backButton.SetActive(true);
        _highscoresText.SetActive(true);
    }

    public void CreditsButton()
    {
        buttonSound.Play();
        _buttons.SetActive(false);
        _exitButton.SetActive(false);
        _backButton.SetActive(true);
        _creditsText.SetActive(true);
    }

    public void ExitButton()
    {
        buttonSound.Play();
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }

    public void BackButton()
    {
        buttonSound.Play();
        _creditsText.SetActive(false);
        _highscoresText.SetActive(false);
        _buttons.SetActive(true);
        _backButton.SetActive(false);
        _exitButton.SetActive(true);
    }
}
