using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class SampleMonoBehaviour : MonoBehaviour
{
    // Use this for initialization
    void Start () {
        var subInstance = new SampleSubclass();
        UnityEngine.Debug.LogWarning(subInstance.SampleMethod());
        UnityEngine.Debug.LogWarning(subInstance.NonvirtualMethod());
        UnityEngine.Debug.LogWarning(SampleSubclass.SampleClassMethod(null, default(int)));

        var genericsInstance = new SampleGenericsClass<SampleSubclass>();
        UnityEngine.Debug.LogWarning(genericsInstance.SampleGenericsMethod(new Doge()));
    }
}
