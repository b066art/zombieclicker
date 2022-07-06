using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieCounter : MonoBehaviour
{
    [SerializeField] private Text _counterText;
    [SerializeField] private GameObject _gameOverMenu;

    public List<GameObject> zombiesList = new List<GameObject>();
    int amountOfZombies = 0;

    private void Update()
    {
        amountOfZombies = zombiesList.Count;

        _counterText.text = amountOfZombies.ToString() + "/10";

        if(amountOfZombies == 10)
        {
            _gameOverMenu.SetActive(true);
        }
    }

    public void AddZombie(GameObject zombieToAdd)
    {
        zombiesList.Add(zombieToAdd);
    }

    public void RemoveZombie(GameObject zombieToRemove)
    {
        zombiesList.Remove(zombieToRemove);
    }
}
