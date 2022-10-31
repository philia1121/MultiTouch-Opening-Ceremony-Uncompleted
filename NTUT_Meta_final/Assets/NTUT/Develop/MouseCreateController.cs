using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace Opening_v1
{
    public class MouseCreateController : MonoBehaviour
    {
        public static MouseCreateController instance
        {
            get
            {
                if (_instance == null)
                    _instance = GameObject.FindObjectOfType<MouseCreateController>();
                return _instance;
            }
        }
        public static MouseCreateController _instance;

        public Transform target;
        public Vector3 bias;
        public UnityEvent onTouch;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var screenPoint = Input.mousePosition + bias;
                var worldPos = Camera.main.ScreenToWorldPoint(screenPoint);
                target.position = worldPos;

                onTouch?.Invoke();
            }
        }
    }
}
