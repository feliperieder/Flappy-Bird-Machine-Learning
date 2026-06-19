using Unity.MLAgents;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(Rigidbody2D))]
public class FlyBehaviour : MonoBehaviour
{
    [SerializeField] private float _velocity = 1.5f;
    [SerializeField] private float _rotationSpeed = 10f;

    private Rigidbody2D _rb;

    private MLBirdAgent agent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        agent = GetComponent<MLBirdAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            FlyUp();
        }
    }

    public void FlyUp()
    {
        _rb.linearVelocity = Vector2.up * _velocity;
        Debug.Log("Flying up");
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, _rb.linearVelocity.y * _rotationSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //GameManager.instance.GameOver();
        agent.Die();
    }
}
