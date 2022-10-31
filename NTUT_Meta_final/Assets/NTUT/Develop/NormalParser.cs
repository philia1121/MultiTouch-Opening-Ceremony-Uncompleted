using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class NormalParser : MonoBehaviour
{
    public Vector3 _forward { get; set; }
    public Vector3 _up { get; set; }
    public VisualEffect vfx;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _forward = transform.forward;
        _up = transform.up;

        vfx.SetVector3("forward", _forward);
        vfx.SetVector3("up", _up);
    }
}
