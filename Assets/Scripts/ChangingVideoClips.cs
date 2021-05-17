using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

[RequireComponent(typeof(VideoPlayer))]
public class ChangingVideoClips : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public VideoClip[] videos;
    public VideoClip theVideo;
    public static int index;
    bool isPlaying = true;

    void Start()
    {
        index = 0;
        videoPlayer = gameObject.GetComponent<VideoPlayer>();
        videoPlayer.loopPointReached += CheckOver;
    }

    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        print("Video Is Over");
        index += 1;
        if (index >= videos.Length)
        {
            index = 0;
        }

        theVideo = videos[index];
        videoPlayer.clip = theVideo;
        videoPlayer.Play();
        isPlaying = true;
    }
}