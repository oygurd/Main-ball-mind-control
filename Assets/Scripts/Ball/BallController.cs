using Sirenix.OdinInspector;
using UnityEngine;

public class BallController : SerializedMonoBehaviour
{
    [SerializeField] private bool isHeld;

    [SerializeField] Transform ballTransform;
    [SerializeField] Rigidbody2D ballRb;

    [SerializeField] CircleCollider2D ballCollider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}