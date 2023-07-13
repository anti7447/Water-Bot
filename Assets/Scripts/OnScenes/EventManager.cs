using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static event Action<bool> GunFlipped;

    public static void OnGunFlipped(bool flip) {
        GunFlipped?.Invoke(flip);
    }
}
