// using System;
using UnityEngine;

// namespace DefaultNamespace
// {

    public class MouseWorld : MonoBehaviour
    {
        private static MouseWorld instance;
        [SerializeField] private LayerMask mousePlaneLayerMask;

        private void Awake()
        {
            instance = this;
        }

        // private void Update()
        // {
        //     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //     Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, mousePlaneLayerMask);
        //     transform.position = raycastHit.point;
        // }

        public static Vector3 GetPosition()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, instance.mousePlaneLayerMask);
            return raycastHit.point;
        }
    }
// }