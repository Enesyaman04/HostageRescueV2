using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.NiceVibrations;

public class titresim : MonoBehaviour
{
    public static titresim instance;
    private void Awake()
    {
        instance = this;
    }


    public void big()
    {
        MMVibrationManager.Haptic(HapticTypes.HeavyImpact);
    }
    public void med()
    {
        MMVibrationManager.Haptic(HapticTypes.MediumImpact);
    }
    public void light()
    {
        MMVibrationManager.Haptic(HapticTypes.LightImpact);
    }
    public void shoot()
    {
        MMVibrationManager.Haptic(HapticTypes.Selection);
    }
}