using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;

public class Spr_Cam : MonoBehaviour
{
    private CinemachineVirtualCamera normalcam;
    private float shaketimer;

    private void Start()
    {
        normalcam = GetComponent<CinemachineVirtualCamera>();
    }
    public void Shakecam(float power, float time)
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
            normalcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = power;
        shaketimer = time;
    }
    private void Update()
    {
        if (shaketimer > 0)
        {
            shaketimer -= Time.deltaTime;
            if (shaketimer <= 0f)
            {
                CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
                    normalcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

                cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0f;
            }
            if (transform.eulerAngles.x != 0 || transform.eulerAngles.y != 0 || transform.eulerAngles.z != 0)
            {
                transform.DORotate(new Vector3(0, 0, 0), 0.5f);
            }
        }
    }

}
