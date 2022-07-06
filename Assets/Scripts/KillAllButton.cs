using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillAllButton : MonoBehaviour
{
    [SerializeField] private Text killAllText;
    [SerializeField] private Text killAllTimerText;
    [SerializeField] private GameObject _zombieCounter;
    [SerializeField] private GameObject _scoreBar;
    [SerializeField] private int killAllCost = 500;
    [SerializeField] private int cooldownTime = 60;
    [SerializeField] private AudioSource bombSound;
    [SerializeField] private AudioSource readySound;

    private Button killAllButton;
    private bool isAvailable = true;

    private void Awake()
    {
        killAllButton = gameObject.GetComponent<Button>();
        killAllText.text = killAllCost.ToString();
    }

    private void Update()
    {
        if(_scoreBar.GetComponent<Score>()._score >= killAllCost && isAvailable && !killAllButton.interactable)
        {
            readySound.Play();
            killAllButton.interactable = true;
        }

        else if(_scoreBar.GetComponent<Score>()._score < killAllCost && !isAvailable)
        {
            killAllButton.interactable = false;
        }
    }

    public void KillAll()
    {
        bombSound.Play();
        StartCoroutine(Cooldown());
        _scoreBar.GetComponent<Score>().SubtractPoints(killAllCost);

        List<GameObject> zombies = _zombieCounter.GetComponent<ZombieCounter>().zombiesList;

        foreach (GameObject zombie in zombies)
        {
            zombie.GetComponent<AIHealth>().Kill();
        }

        zombies.Clear();
    }

    private IEnumerator Cooldown()
    {
        isAvailable = false;
        killAllTimerText.text = cooldownTime.ToString();

        for(int i = 0; i<cooldownTime; i++)
        {
            yield return new WaitForSeconds(1f);
            killAllTimerText.text = (cooldownTime - i).ToString();
        }

        killAllTimerText.text = "";
        isAvailable = true;
    }
}
