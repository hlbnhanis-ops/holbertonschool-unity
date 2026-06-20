using UnityEngine;
using UnityEngine.Video;

public class VideoSphere : MonoBehaviour
{
    private VideoPlayer _videoPlayer;
    private VideoSphereManager _manager;

    void Start()
    {
        _videoPlayer = GetComponent<VideoPlayer>();
        _manager = FindAnyObjectByType<VideoSphereManager>();
    }

    public void OnClick()
    {
        _manager.NavigateTo(_videoPlayer);
    }
}