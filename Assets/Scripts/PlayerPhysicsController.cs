using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysicsController : MonoBehaviour
{
    #region Self Variables

    #region Serialized Variables

    [SerializeField] private PlayerManager manager;
    [SerializeField] private Rigidbody Rigidbody;
    [SerializeField] private Collider Collider;

    #endregion

    #endregion


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
