using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace Opening_v2
{
    public class MouseCreateController : MonoBehaviour
    {
        public Transform target;
        public Vector3 bias;
        public UnityEvent onTouch;

        bool isProcess;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButton(0))
            {
                var screenPoint = Input.mousePosition + bias;
                var worldPos = Camera.main.ScreenToWorldPoint(screenPoint);
                target.position = worldPos;

                if (!isProcess)
                    StartCoroutine(triggerVFX());
            }
        }

        IEnumerator triggerVFX()
        {
            isProcess = true;
            onTouch?.Invoke();
            yield return new WaitForSeconds(1f);
            isProcess = false;
        }
    }
}
