using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public Image ImageCurrent;

    // Start is called before the first frame update
    public void SetValue(float current, float max) =>
         ImageCurrent.fillAmount = current / max;
}
