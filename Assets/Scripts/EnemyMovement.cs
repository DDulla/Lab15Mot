using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 3f;
    private Vector2 direction;

    public void Initialize(Vector2 moveDirection)
    {
        direction = moveDirection;
    }

    private void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
