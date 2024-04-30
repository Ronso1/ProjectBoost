using UnityEngine;
using UnityEngine.UI;

public class ChangeVolume : MonoBehaviour
{
    [SerializeField] private AudioSource _playerAudioSource;
    [SerializeField] private PlayerMenu _playerMenu;
    [SerializeField] private Slider _playerSlider;

    public void SetVolume()
    {
        _playerAudioSource.volume = _playerSlider.value;
        _playerMenu.SetNewVolume(_playerSlider.value);
    }
}
