using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    public bool IsColliding = false;

    void OnCollisionEnter()
    {
        IsColliding = true;
    }
}
