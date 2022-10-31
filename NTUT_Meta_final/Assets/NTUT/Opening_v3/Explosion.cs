using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class Explosion : MonoBehaviour
{
    public Volume m_Volume;
    public Cubemap CubeMap;
    HDRISky sky;
    public Bloom bloom;

    public float m_exposure;
    public float m_degree;
    bool trans = false;
    public float step = 0.1f;

    public Volume m_Volume2;

    // Start is called before the first frame update
    void Start()
    {
        VolumeProfile profile = m_Volume.sharedProfile;
        m_Volume.profile.TryGet(out sky);

        profile = m_Volume2.sharedProfile;
        m_Volume2.profile.TryGet(out bloom);
    }

    public void Update()
    {
        // if( trans && sky.exposure.value < m_exposure)
        // {
        //     sky.exposure.value += step;
        //     Debug.Log("yesssssssssssssss");
        //     if(sky.exposure.value > m_exposure)
        //     {
        //         sky.exposure.value = m_exposure;
        //         trans = false;
        //     }
        // }    
    }
    public void ChangeSkyBox()
    {
        sky.hdriSky.value = CubeMap;
        sky.rotation.value = m_degree;
        sky.exposure.value = m_exposure;
        bloom.intensity.value = 0;
        
    }
}
