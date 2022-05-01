using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField]
    Transform Player;

    void Update()
    {
        transform.position = new Vector3(Player.position.x + 6, transform.position.y, transform.position.z);
    }
}

