using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    [SerializeField] private float _lifeDuration;
    private void FixedUpdate()
    {
        _lifeDuration -= Time.fixedDeltaTime;
        if (_lifeDuration < 0) 
        {
            Destroy(gameObject);
        }
    }
}
