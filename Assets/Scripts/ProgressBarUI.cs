using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
    [SerializeField] private GameObject hasProgressGameObject;
    [SerializeField] private Image barImage;

    private IHasProgress hasProgress;

    private void Start()
    {
        hasProgress = hasProgressGameObject.GetComponent<IHasProgress>();

        if (hasProgress == null)
        {
            Debug.LogError("GO " + hasProgressGameObject + " does not implement IHasProgress");
        }

        hasProgress.OnProgressChanged += HasProgress_OnProgressChanged;

        barImage.fillAmount = 0f;

        Hide();
    }

    private void HasProgress_OnProgressChanged(object sender, IHasProgress.OnProgressChangedEventArgs e)
    {
        Debug.Log(e.progressNormilized);
        barImage.fillAmount = e.progressNormilized;

        if (e.progressNormilized == 0f || e.progressNormilized == 1f)
        {
            Hide();
        }
        else
        {
            Show();
        }
    }

    private void Hide()
    {
        Debug.Log("hide");
        gameObject.SetActive(false);
    }

    private void Show()
    {
        Debug.Log("show");
        gameObject.SetActive(true);
    }
}
