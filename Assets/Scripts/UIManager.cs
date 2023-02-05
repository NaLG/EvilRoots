using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    [SerializeField] private GameObject _playButton;
    private void Awake()
    {
        Seed.OnRoot += OnGameOver;
    }

    private void OnDestroy()
    {
        Seed.OnRoot -= OnGameOver;
    }

    public void RestartGame() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    private void OnGameOver() => _playButton.SetActive(true);
}
