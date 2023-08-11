using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
    [SerializeField] private CuttingCounter cuttingCounter;
    [SerializeField] private Image barImage;

    private void Start()
    {
        cuttingCounter.OnProgressChanged += CuttingCounter_OnProgressChanged;

        barImage.fillAmount = 0f;

        Hide();
    }

    private void CuttingCounter_OnProgressChanged(object sender, CuttingCounter.OnProgressChangedEventArgs e)
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
