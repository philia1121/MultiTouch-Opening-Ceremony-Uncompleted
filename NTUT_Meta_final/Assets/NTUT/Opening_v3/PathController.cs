using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using Opening_v1;

public class PathController : MonoBehaviour
{
    public VisualEffect vfx;
    public Vector3 SphereMotionAmplitude = new Vector3(3,2,2);
    public Vector3 SphereMotionSpeed = new Vector3(3.98f, 4.78f, 5.87f);

    public Vector3 current;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        current = Vector3.Lerp(current, GetPathPosition(0, Time.time), Time.deltaTime);
        vfx.SetVector3("getPos", current);
    }

    public void set()
    {
        current = MouseCreateController.instance.target.position;
    }

    public Vector3 GetPathPosition(int id,float time)
    {
        Vector3 point = (time + id) * SphereMotionSpeed;
        Vector3 sine = new Vector3(Mathf.Sin(point.x), Mathf.Sin(point.y), Mathf.Sin(point.z));
        Vector3 cosine = new Vector3(Mathf.Cos(point.x), Mathf.Cos(point.y), Mathf.Cos(point.z));

        Vector3 newPos = new Vector3(sine.y,cosine.x, cosine.y);
        newPos.Scale(SphereMotionAmplitude);
        newPos *= 1.4f;

        return newPos;
    }
}

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using TouchScript;
using TouchScript.Pointers;

public class PathController : MonoBehaviour
{
    Dictionary<Pointer, GameObject> BallArray = new Dictionary<Pointer, GameObject>();

    private void OnEnable()
    {
        if (TouchManager.Instance != null)
        {
            TouchManager.Instance.PointersPressed += pointersPressedHandler;
            TouchManager.Instance.PointersReleased += pointersReleaseHandler;
        }

    }

    private void OnDisable()
    {
        if (TouchManager.Instance != null)
        {
            TouchManager.Instance.PointersPressed -= pointersPressedHandler;
            TouchManager.Instance.PointersReleased -= pointersReleaseHandler;
        }
    }

    private void pointersPressedHandler(object sender, PointerEventArgs e)
    {
        foreach (var pointer in e.Pointers)
        {
            print(pointer.Id + ":pressed");
        }
    }

    private void pointersReleaseHandler(object sender, PointerEventArgs e)
    {
        foreach (var pointer in e.Pointers)
        {
            BallArray.Remove(pointer);
            print(pointer.Id + ":released");
        }
    }
}*/

