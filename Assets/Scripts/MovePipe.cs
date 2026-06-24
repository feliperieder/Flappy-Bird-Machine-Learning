using UnityEngine;

public class MovePipe : MonoBehaviour
{
    [SerializeField] private float _initialSpeed = 0.65f;
    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * _initialSpeed * Time.deltaTime;
        Debug.Log(Time.timeScale);
    }
}
