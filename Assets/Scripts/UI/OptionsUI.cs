using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionsUI : MonoBehaviour
{
    [Header("Sound and music")]
    [SerializeField] private Button soundEffectButton;
    [SerializeField] private Button musicButton;
    [SerializeField] private Button backButton;
    [SerializeField] private TextMeshProUGUI soundEffectText;
    [SerializeField] private TextMeshProUGUI musicText;

    //game controls
    [Header("Game Controls")]
    [Header("-Keyboard-")]
    [Header("KeyText")]
    [SerializeField] private TextMeshProUGUI moveUpText;
    [SerializeField] private TextMeshProUGUI moveDownText;
    [SerializeField] private TextMeshProUGUI moveLeftText;
    [SerializeField] private TextMeshProUGUI moveRightText;
    [SerializeField] private TextMeshProUGUI InteractText;
    [SerializeField] private TextMeshProUGUI InteractAltText;
    [SerializeField] private TextMeshProUGUI PauseText;

    [Header("Buttons")]
    [SerializeField] private Button moveUpButton;
    [SerializeField] private Button moveDownButton;
    [SerializeField] private Button moveLeftButton;
    [SerializeField] private Button moveRightButton;
    [SerializeField] private Button InteractButton;
    [SerializeField] private Button InteractAltButton;
    [SerializeField] private Button PauseButton;

    [Header("-Gamepad-")]
    [Header("KeyText")]
    [SerializeField] private TextMeshProUGUI InteractGamepadText;
    [SerializeField] private TextMeshProUGUI InteractAltGamepadText;
    [SerializeField] private TextMeshProUGUI PauseGamepadText;

    [Header("Buttons")]
    [SerializeField] private Button InteractGamepadButton;
    [SerializeField] private Button InteractAltGamepadButton;
    [SerializeField] private Button PauseGamepadButton;

    [Header("Optional")]
    [SerializeField] private Transform pressToRebindKeyTransform;

    private Action OnCloseButtonAction;

    private void Awake()
    {
        soundEffectButton.onClick.AddListener(() =>
        {
            SoundManager.Instance.ChangeVolume();
            UpdateVisual();
        });

        musicButton.onClick.AddListener(() =>
        {
            MusicManager.Instance.ChangeVolume();
            UpdateVisual();
        });

        backButton.onClick.AddListener(() =>
        {
            OnCloseButtonAction();
            Hide();
        });

        //keyboard
        moveUpButton.onClick.AddListener(() => { RebindBinding(GameInput.Binding.Move_Up);  });
        moveDownButton.onClick.AddListener(() => { RebindBinding(GameInput.Binding.Move_Down);  });
        moveLeftButton.onClick.AddListener(() => { RebindBinding(GameInput.Binding.Move_Left);  });
        moveRightButton.onClick.AddListener(() => { RebindBinding(GameInput.Binding.Move_Right);  });
        InteractButton.onClick.AddListener(() => { RebindBinding(GameInput.Binding.Interact);  });
        InteractAltButton.onClick.AddListener(() => { RebindBinding(GameInput.Binding.InteractAlt);  });
        PauseButton.onClick.AddListener(() => { RebindBinding(GameInput.Binding.Pause);  });
        //gamepad
        InteractGamepadButton.onClick.AddListener(() => { RebindBinding(GameInput.Binding.Gamepad_Interact); });
        InteractAltGamepadButton.onClick.AddListener(() => { RebindBinding(GameInput.Binding.Gamepad_InteractAlt); });
        PauseGamepadButton.onClick.AddListener(() => { RebindBinding(GameInput.Binding.Gamepad_Pause); });

    }

    private void Start()
    {
        UpdateVisual();
        Hide();
        HidePressToRebindKey();

        GameManager.Instance.OnGamePaused += GameManager_OnGamePaused;
    }

    private void GameManager_OnGamePaused(object sender, System.EventArgs e)
    {
        Hide();
    }

    private void UpdateVisual()
    {
        soundEffectText.text = "Sound Effect: " + Mathf.Round(SoundManager.Instance.GetVolume() * 10f);
        musicText.text = "Music: " + Mathf.Round(MusicManager.Instance.GetVolume() * 10f);

        moveUpText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Up);
        moveDownText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Down);
        moveLeftText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Left);
        moveRightText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Right);
        InteractText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Interact);
        InteractAltText.text = GameInput.Instance.GetBindingText(GameInput.Binding.InteractAlt);
        PauseText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Pause);

        InteractGamepadText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Gamepad_Interact);
        InteractAltGamepadText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Gamepad_InteractAlt);
        PauseGamepadText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Gamepad_Pause);
    }

    public void Show(Action OnCloseButonAction)
    {
        this.OnCloseButtonAction = OnCloseButonAction;
        gameObject.SetActive(true);

        backButton.Select();
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private void ShowPressToRebindKey()
    {
        pressToRebindKeyTransform.gameObject.SetActive(true);
    }

    private void HidePressToRebindKey()
    {
        pressToRebindKeyTransform.gameObject.SetActive(false);
    }

    private void RebindBinding(GameInput.Binding binding)
    {
        ShowPressToRebindKey();
        GameInput.Instance.RebindRebinding(binding, () =>
        {
            HidePressToRebindKey();
            UpdateVisual();
        });
    }
}
