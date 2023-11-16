using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    private struct AudioInfo
    {
        public AudioSource source;
        public bool wasPlaying;
    }

    private List<AudioInfo> audioInfos = new List<AudioInfo>();

    void Start()
    {
        // Mendapatkan semua AudioSource dalam scene
        AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();

        // Menyimpan informasi status setiap AudioSource
        foreach (var audioSource in allAudioSources)
        {
            audioInfos.Add(new AudioInfo
            {
                source = audioSource,
                wasPlaying = audioSource.isPlaying
            });
        }
    }


    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;

        PauseAllAudioSources();
    }

    public void Exit()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;

        ResumeAllAudioSources();
    }

    private void PauseAllAudioSources()
    {
        foreach (var audioInfo in audioInfos)
        {
            audioInfo.source.Pause();
        }
    }

    // Memulai kembali semua AudioSource
    private void ResumeAllAudioSources()
    {
        foreach (var audioInfo in audioInfos)
        {
            if (audioInfo.wasPlaying)
            {
                audioInfo.source.Play();
            }
        }
    }
}
