using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clean : MonoBehaviour
{
    void OnTriggerEnter(Collider other) {
        Destroy(other.gameObject);
    }
}
