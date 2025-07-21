using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace Script
{
    public class BackToPose : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private Rigidbody rb;
        [SerializeField] private InputActionReference pressButton;
        [SerializeField] private bool active;


        private void Start()
        {
            if (pressButton)
                pressButton.action.started += _ => Recall();
            
        }

        private void Update()
        {
            if (!active) return;
            
            rb.position = target.position;
            rb.rotation = target.rotation;
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        public void Recall()
        {
            active = true;
        }

        public void Release()
        {
            active = false;
        }
    }
}
