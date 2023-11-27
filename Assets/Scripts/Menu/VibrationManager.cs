using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CandyCoded;
using CandyCoded.HapticFeedback;

public class VibrationManager : MonoBehaviour
{
    #region PUBLIC_METHODS

    public void HeavyVibration()
    {
        HapticFeedback.HeavyFeedback();
    }

    public void MediumVibration()
    {
        HapticFeedback.MediumFeedback();
    }

    public void LightVibration()
    {
        HapticFeedback.LightFeedback();
    }

    #endregion
}