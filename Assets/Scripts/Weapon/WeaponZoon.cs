using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] GameObject zoomCamera;
    [SerializeField] float zoomOutFOV = 60f;
    [SerializeField] float zoomInFOV = 30f;
    [SerializeField] float zoomTransitionSpeed = 10f;

    private CinemachineVirtualCamera virtualCamera;
    private Coroutine zoomCoroutine;

    private void Start()
    {
        if (zoomCamera != null)
        {
            virtualCamera = zoomCamera.GetComponent<CinemachineVirtualCamera>();
            if (virtualCamera == null)
            {
                Debug.LogError("CinemachineVirtualCamera component not found on the zoomCamera GameObject.");
            }
        }
        else
        {
            Debug.LogError("Zoom Camera GameObject is not assigned.");
        }
    }

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            if (zoomCoroutine != null)
            {
                StopCoroutine(zoomCoroutine);
            }
            zoomCoroutine = StartCoroutine(SmoothZoom(zoomInFOV));
        }
        else
        {
            if (zoomCoroutine != null)
            {
                StopCoroutine(zoomCoroutine);
            }
            zoomCoroutine = StartCoroutine(SmoothZoom(zoomOutFOV));
        }
    }

    private IEnumerator SmoothZoom(float targetFOV)
    {
        float currentFOV = virtualCamera.m_Lens.FieldOfView;
        while (Mathf.Abs(currentFOV - targetFOV) > 0.1f)
        {
            currentFOV = Mathf.Lerp(currentFOV, targetFOV, Time.deltaTime * zoomTransitionSpeed);
            virtualCamera.m_Lens.FieldOfView = currentFOV;
            yield return null;
        }
        virtualCamera.m_Lens.FieldOfView = targetFOV;
    }
}
