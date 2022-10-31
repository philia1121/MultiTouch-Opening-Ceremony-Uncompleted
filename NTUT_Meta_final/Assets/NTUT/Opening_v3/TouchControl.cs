using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using TouchScript;
using TouchScript.Pointers;
using UnityEngine.Events;

public class TouchControl : MonoBehaviour
{
    public UnityEvent onPressed;
    public UnityEvent onReleased;

    Dictionary<Pointer, VisualEffect> _dict = new Dictionary<Pointer, VisualEffect>();
    public List<VisualEffect> VFXs;

    float zOffset = 0.8f;
    //public Queue<VisualEffect> VFXs = new Queue<VisualEffect>();

    private void OnEnable()
    {
        if (TouchManager.Instance != null)
        {
            TouchManager.Instance.PointersPressed += pointersPressedHandler;
            TouchManager.Instance.PointersUpdated += pointersUpdateHandler;
            TouchManager.Instance.PointersReleased += pointersReleaseHandler;
        }

    }

    private void OnDisable()
    {
        if (TouchManager.Instance != null)
        {
            TouchManager.Instance.PointersPressed -= pointersPressedHandler;
            TouchManager.Instance.PointersUpdated -= pointersUpdateHandler;
            TouchManager.Instance.PointersReleased -= pointersReleaseHandler;
        }
    }

    private void pointersPressedHandler(object sender, PointerEventArgs e)
    {
        foreach (var pointer in e.Pointers)
        {
            Debug.Log(pointer.Id + ":pressed");
            onPressed?.Invoke();

            //領走最前面的vfx
            _dict.Add(pointer, VFXs[0]);
            //傳給它生成座標
            VFXs[0].SetVector3("initPos", Camera.main.ScreenToWorldPoint(new Vector3(pointer.Position.x, pointer.Position.y, zOffset)));
            //並啟動
            VFXs[0].SendEvent("OnTouch");
            //將剛剛領的vfx從清單中移除
            VFXs.RemoveAt(0);
        }
    }

    private void pointersUpdateHandler(object sender, PointerEventArgs e)
    {
        foreach (var pointer in e.Pointers)
        {
            try
            {
                //更新生成座標
                _dict[pointer].SetVector3("initPos", Camera.main.ScreenToWorldPoint(new Vector3(pointer.Position.x, pointer.Position.y, zOffset)));
            }
            catch
            {

            }
        }
    }

    private void pointersReleaseHandler(object sender, PointerEventArgs e)
    {
        foreach (var pointer in e.Pointers)
        {
            Debug.Log(pointer.Id + ":released");
            onReleased?.Invoke();

            //停止視覺化
            _dict[pointer].SendEvent("OnRelease");
            //將特效還回清單
            VFXs.Add(_dict[pointer]);
            //清空dict
            _dict.Remove(pointer);
        }
    }
}