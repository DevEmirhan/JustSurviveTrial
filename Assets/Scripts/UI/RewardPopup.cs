using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardPopup : MonoBehaviour
{
    [SerializeField] private Animator popUpAnim;
    [SerializeField] private string showClip;
    [SerializeField] private string HideClip;
    [SerializeField] private GameObject successBar;
    [SerializeField] private GameObject failbarBar;

    public void Show(bool rewardSucces)
    {
        if (rewardSucces)
        {
            successBar.SetActive(true);
            failbarBar.SetActive(false);
        }
        else
        {
            successBar.SetActive(false);
            failbarBar.SetActive(true);
        }
        gameObject.SetActive(true);
        popUpAnim.Play(showClip, 0, 0);
    }

    public void Hide()
    {
        popUpAnim.Play(HideClip, 0, 0);
    }

    public void DisablePopUp()
    {
        gameObject.SetActive(false);
    }
}
