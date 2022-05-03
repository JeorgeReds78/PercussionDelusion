using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle : MonoBehaviour
{
    float speed;
    //private float velocity = Random.Range(1.0f, 7.0f);
    private void Start()
    {
        speed = Random.Range(1, 8);
    }

    [SerializeField]
    private Vector3[] positions;

    private int index;

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, positions[index], Time.deltaTime * speed);

        if (transform.position == positions[index])
        {
            if (index == positions.Length - 1)
            {
                index = 0;
            }
            else
            {
                index++;
            }
        }

    }
}


