using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AIHealth : MonoBehaviour
{
    [SerializeField] private GameObject bloodFX;
    [SerializeField] private GameObject bloodFXPosition;
    [SerializeField] private int health;
    [SerializeField] private int points;
    [SerializeField] private float destroyTime;
    [SerializeField] private AudioSource hurtSound;

    private Animator animator;
    private GameObject counterText;
    private GameObject scoreText;

    private bool isDead = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
        counterText = GameObject.Find("ZombieCounter");
        scoreText = GameObject.Find("ScoreBar");
    }

    private void Update()
    {
        if(health == 0 && !isDead)
        {
            isDead = true;
            Die();
        }
    }

    public void DecreaseHealth()
    {
        Instantiate(bloodFX, bloodFXPosition.transform.position, Quaternion.Euler(0, 0, 90));
        health--;
    }

    public void DecreaseAllHealth()
    {
        Instantiate(bloodFX, bloodFXPosition.transform.position, Quaternion.Euler(0, 0, 90));
        health = 0;
    }

    private void Die()
    {
        hurtSound.pitch = Random.Range(0.75f, 1.25f);
        hurtSound.Play();
        gameObject.GetComponent<AIMovement>().enabled = false;
        gameObject.GetComponent<Animator>().enabled = false;
        gameObject.GetComponent<Collider>().enabled = false;
        gameObject.GetComponent<AIRagdoll>().RagdollOn();
        counterText.GetComponent<ZombieCounter>().RemoveZombie(gameObject);
        scoreText.GetComponent<Score>().AddPoints(points);
        StartCoroutine(WaitAndDestroy());
    }

    public void Kill()
    {
        Instantiate(bloodFX, bloodFXPosition.transform.position, Quaternion.Euler(0, 0, 90));
        gameObject.GetComponent<AIMovement>().enabled = false;
        gameObject.GetComponent<Animator>().enabled = false;
        gameObject.GetComponent<Collider>().enabled = false;
        gameObject.GetComponent<AIRagdoll>().RagdollOn();
        StartCoroutine(WaitAndDestroy());
    }

    private IEnumerator WaitAndDestroy()
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(gameObject);
    }
}