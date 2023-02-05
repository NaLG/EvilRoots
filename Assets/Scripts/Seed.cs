using System;
using UnityEngine;

public class Seed : MonoBehaviour
{

    public static event Action OnRoot;

    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _force;
    [SerializeField] private float _yBound;

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
        OnRoot?.Invoke();
        Time.timeScale = 0f;
    }

    private void Flutter()
    {
        _rigidbody.velocity = Vector2.zero;
        _rigidbody.AddForce(Vector2.up * _force);
    }
}
