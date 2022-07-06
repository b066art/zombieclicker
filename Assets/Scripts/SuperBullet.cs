using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SuperBullet : MonoBehaviour
{
    [SerializeField] private Text superBulletText;
    [SerializeField] private Text superBulletTimerText;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _scoreBar;
    [SerializeField] private float durationTime = 10f;
    [SerializeField] private int superBulletCost = 300;
    [SerializeField] private int cooldownTime = 60;
    [SerializeField] private AudioSource reloadSound;
    [SerializeField] private AudioSource readySound;

    private Button superBulletButton;
    private bool isAvailable = true;

    private void Awake()
    {
        superBulletButton = gameObject.GetComponent<Button>();
        superBulletText.text = superBulletCost.ToString();
    }

    private void Update()
    {
        if(_scoreBar.GetComponent<Score>()._score >= superBulletCost && isAvailable && !superBulletButton.interactable)
        {
            readySound.Play();
            superBulletButton.interactable = true;
        }

        else if(_scoreBar.GetComponent<Score>()._score < superBulletCost && !isAvailable)
        {
            superBulletButton.interactable = false;
        }
    }

    public void SuperBulletMode()
    {
        reloadSound.Play();
        StartCoroutine(Cooldown());
        _scoreBar.GetComponent<Score>().SubtractPoints(superBulletCost);
        StartCoroutine(_player.GetComponent<TargetClicker>().SetSuperBulletMode(durationTime));
    }

    private IEnumerator Cooldown()
    {
        isAvailable = false;
        superBulletTimerText.text = cooldownTime.ToString();

        for(int i = 0; i<cooldownTime; i++)
        {
            yield return new WaitForSeconds(1f);
            superBulletTimerText.text = (cooldownTime - i).ToString();
        }

        superBulletTimerText.text = "";
        isAvailable = true;
    }
}
