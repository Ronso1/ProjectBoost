using UnityEngine;
using UnityEngine.UI;

public class PlayerMenu : MonoBehaviour
{
    [SerializeField] private AudioSource _playerAudioSource;
    [SerializeField] private GameObject _playerMenu;
    [SerializeField] private Slider _playerSlider;

    public static float _audioVolume = 0.5f;

    private bool _menuActive = false;

    private void Start()
    {
        _playerSlider.value = _audioVolume;
        _playerAudioSource.volume = _audioVolume;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && _menuActive == false)
        {
            _menuActive = true;
            _playerAudioSource.Pause();
            Time.timeScale = 0f;
            _playerMenu.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && _menuActive)
        {
            _menuActive = false;
            _playerAudioSource.Play();
            Time.timeScale = 1f;
            _playerMenu.SetActive(false);
        }

    }

    public void SetNewVolume(float volume)
    {
        _audioVolume = volume;
    }
}
