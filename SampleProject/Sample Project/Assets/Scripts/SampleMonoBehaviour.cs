using UnityEngine;
using System.Collections;
using System.Collections.Generic;
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

        Dictionary<int, int> dict = new Dictionary<int, int>();
        Dictionary<int, int> dict1 = new Dictionary<int, int>(1);
        Dictionary<int, int> dict9 = new Dictionary<int, int>(9);
        Dictionary<int, int> dict18 = new Dictionary<int, int>(18);
        Dictionary<int, int> dict98 = new Dictionary<int, int>(98);
        Dictionary<int, int> dict99 = new Dictionary<int, int>(99);
        Dictionary<int, int> dict100 = new Dictionary<int, int>(100);
        var i = dict.Count;

        List<int> list = new List<int>(3);

        i = dict.Count;
    }
}
