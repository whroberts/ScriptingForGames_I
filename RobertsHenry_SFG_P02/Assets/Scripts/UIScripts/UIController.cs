using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIController : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] GameObject _pauseMenu = null;
    [SerializeField] GameObject _settingsMenu = null;

    [Header("Sensitivity")]
    [SerializeField] Slider _sensitivitySld = null;
    [SerializeField] Text _settingsValue = null;

    [Header("Scripts")]
    [SerializeField] MouseLook _mouseLook = null;

    [Header("Variables")]
    public bool _isPaused = false;

    GlobalLevelController _glc;

    private void Awake()
    {
        _glc = FindObjectOfType<GlobalLevelController>();
    }

    private void Start()
    {
        _sensitivitySld.value = _mouseLook._mouseSensitivity;
        SetSensitivity();
    }

    public void PauseLevel()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        _isPaused = true;
        _glc.PlayerControls(0);
        _pauseMenu.SetActive(true);
    }

    public void ResumeLevel()
    {
        Cursor.visible = false;
        _isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        _glc.PlayerControls(1);
        _pauseMenu.SetActive(false);
    }

    public void SetSensitivity()
    {

        _settingsValue.text = _mouseLook._mouseSensitivity.ToString();
        _mouseLook._mouseSensitivity = (int) _sensitivitySld.value;
    }
}
