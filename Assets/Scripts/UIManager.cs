using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{

    [SerializeField] private GameObject _playButton;
    [SerializeField] private TMP_Text _score;
    private void Awake()
    {
        Seed.OnRoot += OnGameOver;
        Seed.OnScore += OnScore;
    }

    private void OnDestroy()
    {
        Seed.OnRoot -= OnGameOver;
        Seed.OnScore -= OnScore;
    }

    public void RestartGame() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    private void OnGameOver() => _playButton.SetActive(true);
    private void OnScore() => _score.text = (int.Parse(_score.text) + 1).ToString();
}
