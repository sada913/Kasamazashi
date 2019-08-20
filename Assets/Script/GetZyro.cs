﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetZyro : MonoBehaviour
{
    [SerializeField] Text Text;
    PhotonView pv;
    // Update is called once per frame
    private void Start()
    {
        PhotonNetwork.sendRate = 60;
        pv = GetComponent<PhotonView>();
    }

    void Update()
    {
        if (!pv.isMine)
            return;
#if UNITY_iOS
        var rotRH = Input.gyro.attitude;
        var rot = new Quaternion(-rotRH.x, -rotRH.z, -rotRH.y, rotRH.w) * Quaternion.Euler(90f, 0f, 0f);

        transform.localRotation = rot;
        string rot_string = rot.eulerAngles.ToString();
        Text.text = rot_string;
#endif
    }
}
