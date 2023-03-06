using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;


public class ColorChange : MonoBehaviour
{
    [SerializeField] Volume globalVolume;
    [SerializeField] Bloom b;
    void Start()
    {
        globalVolume = GetComponentInChildren<Volume>();
        globalVolume.profile.TryGet(out b);
        StartCoroutine(ColorSwap(2));
    }

    IEnumerator ColorSwap(Int32 waitForSwap)
    {
        b.tint.value = Color.red;
        yield return new WaitForSeconds(waitForSwap);;
        b.tint.value = Color.yellow;
        yield return new WaitForSeconds(waitForSwap);
        b.tint.value = Color.blue;
        yield return new WaitForSeconds(waitForSwap);
        b.tint.value = Color.gray;
        yield return new WaitForSeconds(waitForSwap);
        b.tint.value = Color.magenta;
        yield return new WaitForSeconds(waitForSwap);
        b.tint.value = Color.cyan;
        yield return new WaitForSeconds(waitForSwap);
        b.tint.value = Color.green;
        yield return new WaitForSeconds(waitForSwap);
        b.tint.value = Color.grey;
        yield return new WaitForSeconds(waitForSwap);
        StartCoroutine(ColorSwap(4));
    }
}
