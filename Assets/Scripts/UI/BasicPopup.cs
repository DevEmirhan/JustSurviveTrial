using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPopup : MonoBehaviour
{
    [SerializeField] private Animator popUpAnim;
    [SerializeField] private string showClip;
    [SerializeField] private string HideClip;
    [SerializeField] private bool isAnimated;

    public void Show()
    {
        if (isAnimated)
        {
            gameObject.SetActive(true);
            popUpAnim.Play(showClip,0,0);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }

    public void Hide()
    {
        if (isAnimated)
        {
            popUpAnim.Play(HideClip, 0, 0);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
    public void DisablePopUp()
    {
        gameObject.SetActive(false);
    }
}
