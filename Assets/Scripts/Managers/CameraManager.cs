using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : Singleton<CameraManager>
{
    [SerializeField] private List<CinemachineVirtualCamera> cmCameras = new List<CinemachineVirtualCamera>();
    public CinemachineVirtualCamera currentCamera;

    public void ActivateCamera(int CameraIndex)
    {
        foreach (var camera in cmCameras)
        {
            camera.gameObject.SetActive(false);
        }
        cmCameras[CameraIndex].gameObject.SetActive(true);
    }

    public void DoFov()
    {
        //CinemachineFramingTransposer transposer = currentCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
        //DOTween.To(() => transposer.m_CameraDistance, x => transposer.m_CameraDistance = x, 10, 0.5f);
    }
    public void DoZoomOut()
    {
        //CinemachineFramingTransposer transposer = currentCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
        //DOTween.To(() => transposer.m_CameraDistance, x => transposer.m_CameraDistance = x, 25, 0.5f);
    }
    public void DoZoomIn()
    {
        //CinemachineFramingTransposer transposer = currentCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
        //DOTween.To(() => transposer.m_CameraDistance, x => transposer.m_CameraDistance = x, 17, 0.5f);
    }
}
