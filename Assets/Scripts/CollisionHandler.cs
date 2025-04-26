using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    [SerializeField] float levelLoadDelay = 1.5f;
    [SerializeField] float levelLoadDelayFinish = 1f;
    [SerializeField] AudioClip successEngineSFX;
    [SerializeField] AudioClip crashEngineSFX;
    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem crashParticles;

    AudioSource audioSource;
    bool isControllable = true;
    bool isConllidable = true;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        RespondToDebugKeys();
    }

    void RespondToDebugKeys()
    {
        if (Keyboard.current.lKey.wasPressedThisFrame) // Tekan "L" keyboard untuk melakukan reload dalam Game
        {
            Debug.Log("Skip level is Activated");
            LoadNextLevel();
        }
        else if (Keyboard.current.cKey.wasPressedThisFrame) // Tekan "C" keyboard untuk menghilangkan effect (crash) ibaratnya anda ngecit
        {
            isConllidable = !isConllidable;
            Debug.Log(isConllidable ? "Cheat Immune is Not Activated" : "Cheat Immune is Activated");
        }
    }


    private void OnCollisionEnter(Collision other)
    {
        if (!isControllable || !isConllidable)
        {
            return;
        }
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Mulai, disini aman kok!!!");
                break;
            case "Finish":
                Debug.Log("Kerja Bagus, akhirnya Sampai !!!");
                StartSuccessSequence();
                break;
            case "Fuel":
                Debug.Log("Ah tidak, sakit sekali !!!");
                StartCrashSequence();
                break;
            default:
                Debug.Log("Tidak, kamu kecelakaan");
                StartCrashSequence();
                break;
        }
    }

    void StartSuccessSequence()
    {
        isControllable = false;
        audioSource.Stop();
        audioSource.PlayOneShot(successEngineSFX);
        successParticles.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", levelLoadDelayFinish);
    }

    void StartCrashSequence()
    {
        isControllable = false;
        audioSource.Stop();
        audioSource.PlayOneShot(crashEngineSFX);
        crashParticles.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", levelLoadDelay);
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


// Nanti menambahkan asset obstacle lain
