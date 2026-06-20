using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.Video;

public class VideoSphereManager : MonoBehaviour
{
    public VideoPlayer InitialSphere;
    private VideoPlayer _selectedSphere;
    private XROrigin _xrOrigin;

    void Start()
    {
        _xrOrigin = FindAnyObjectByType<XROrigin>();
        NavigateTo(InitialSphere);
    }

    public void NavigateTo(VideoPlayer sphere)
    {
        if (_selectedSphere != null)
            _selectedSphere.Stop();
        _selectedSphere = sphere;
        _selectedSphere.Play();
        _xrOrigin.transform.position = _selectedSphere.transform.position;
    }
}