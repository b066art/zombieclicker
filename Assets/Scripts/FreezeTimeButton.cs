using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FreezeTimeButton : MonoBehaviour
{
    [SerializeField] private Text freezeTimeText;
    [SerializeField] private Text freezeTimeTimerText;
    [SerializeField] private GameObject _zombieSpawner;
    [SerializeField] private GameObject _scoreBar;
    [SerializeField] private float freezeTime = 10f;
    [SerializeField] private int freezeTimeCost = 200;
    [SerializeField] private int cooldownTime = 60;
    [SerializeField] private AudioSource timeSound;
    [SerializeField] private AudioSource readySound;

    private Button freezeTimeButton;
    private bool isAvailable = true;

    private void Awake()
    {
        freezeTimeButton = gameObject.GetComponent<Button>();
        freezeTimeText.text = freezeTimeCost.ToString();
    }

    private void Update()
    {
        if(_scoreBar.GetComponent<Score>()._score >= freezeTimeCost && isAvailable && !freezeTimeButton.interactable)
        {
            readySound.Play();
            freezeTimeButton.interactable = true;
        }
        
        else if(_scoreBar.GetComponent<Score>()._score < freezeTimeCost && !isAvailable)
        {
            freezeTimeButton.interactable = false;
        }
    }

    public void FreezeTime()
    {
        timeSound.Play();
        StartCoroutine(Cooldown());
        _scoreBar.GetComponent<Score>().SubtractPoints(freezeTimeCost);
        _zombieSpawner.GetComponent<ZombieSpawner>().SetSpawnTime();
        _zombieSpawner.GetComponent<ZombieSpawner>().SetSpawnInterval(freezeTime);
    }

    private IEnumerator Cooldown()
    {
        isAvailable = false;
        freezeTimeTimerText.text = cooldownTime.ToString();

        for(int i = 0; i<cooldownTime; i++)
        {
            yield return new WaitForSeconds(1f);
            freezeTimeTimerText.text = (cooldownTime - i).ToString();
        }

        freezeTimeTimerText.text = "";
        isAvailable = true;
    }
}
