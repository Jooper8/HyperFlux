using Cinemachine;
using UnityEngine;
[ExecuteInEditMode]
[SaveDuringPlay]
[AddComponentMenu("")]
public class CameraLock : CinemachineExtension
{
    [Tooltip("Lock the camera's X position to this value")]
    public float m_XPosition = 0;

    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (stage == CinemachineCore.Stage.Body)
        {
            var pos = state.RawPosition;
            pos.x = m_XPosition;
            state.RawPosition = pos;
        }
    }
}