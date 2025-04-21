// using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Mulai, disini aman kok!!!");
                break;
            case "Finish":
                Debug.Log("Kerja Bagus, akhirnya Sampai !!!");
                LoadNextLevel();
                break;
            case "Fuel":
                Debug.Log("Ah tidak, sakit sekali !!!");
                ReloadLevel();
                break;
            default:
                Debug.Log("Tidak, kamu kecelakaan");
                ReloadLevel();
                break;
        }

        void ReloadLevel()
        {
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentScene);
        }

        void LoadNextLevel()
        {
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            int nextScene = currentScene + 1;
            if (nextScene == SceneManager.sceneCountInBuildSettings)
            {
                nextScene = 0;
            }
            SceneManager.LoadScene(nextScene);
        }

    }


    //[SerializeField] float levelLoadDelay = 0f;
    //[SerializeField] AudioClip successEngine;
    //[SerializeField] AudioClip crashEngine;

    //AudioSource audioSource;

    //bool isControllable = true;


    //private void Start()
    //{
    //    audioSource = GetComponent<AudioSource>();
    //}
    //private void OnCollisionEnter(Collision other)
    //{
    //    if (isControllable)
    //    {
    //        return;
    //    }
    //    switch (other.gameObject.tag)
    //    {
    //        case "Friendly":
    //           Debug.Log("Semuanya terlihat Baik !!!");
    //            break;
    //        case "Finish":
    //            Debug.Log("Permainan Selesai !!!");
    //            StartSuccessSequence();
    //            break;
    //        default:
    //            Debug.Log("Anda Kecelakaan !!!");
    //            StartCrashSequence();
    //           break;
    //    }

    //}

    //void StartSuccessSequence()
    //{
    //    audioSource.PlayOneShot(successEngine);
    //GetComponent<Movement>().enabled = false;
    //    Invoke("LoadNextLevel", levelLoadDelay);
    //}

    //void StartCrashSequence()
    //{
    //    audioSource.PlayOneShot(crashEngine);
    //GetComponent<Movement>().enabled = false;
    //    Invoke("ReloadLevel", levelLoadDelay);
    //}

    //void LoadNextLevel()
    //{
    //    int currentScene = SceneManager.GetActiveScene().buildIndex;
    //    int nextScene = currentScene + 1;

    //    if (nextScene == SceneManager.sceneCountInBuildSettings)
    //   {
    //        nextScene = 0;
    //    }
    //    SceneManager.LoadScene(nextScene);
    //}

    //void ReloadLevel()
    //{
    //    int currentScene = SceneManager.GetActiveScene().buildIndex;
    //    SceneManager.LoadScene(currentScene);
    //}
}
