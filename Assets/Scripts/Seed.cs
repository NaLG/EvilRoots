using System;
using UnityEngine;

public class Seed : MonoBehaviour
{

    public static event Action OnRoot;
    public static event Action OnScore;

    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _force;
    [SerializeField] private float _yBound;

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _flutterSound;
    [SerializeField] private AudioClip _scoreSound;
    [SerializeField] private AudioClip _rootSound;

    private void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && _rigidbody.position.y < _yBound)
        {
            Flutter();
        }

    }

    private void OnCollisionEnter2D()
    {
        Debug.Log("You dead.");
        OnRoot?.Invoke();
        Time.timeScale = 0f;

        _audioSource.PlayOneShot(_rootSound);       
    }

    private void OnTriggerExit2D()
    {
        Debug.Log("Score triggered.");
        OnScore?.Invoke();

        _audioSource.PlayOneShot(_scoreSound);
    }

    private void Flutter()
    {
        _rigidbody.velocity = Vector2.zero;
        _rigidbody.AddForce(Vector2.up * _force);

        _audioSource.PlayOneShot(_flutterSound);
    }
}
