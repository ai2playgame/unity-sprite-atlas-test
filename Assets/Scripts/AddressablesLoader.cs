using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class AddressablesLoader : MonoBehaviour
{
    void Start()
    {
        for (int i = 1; i <= 4; ++i)
        {
            var address = $"Assets/Prefabs/Sprites {i}.prefab";
            Addressables.LoadAssetAsync<GameObject>(address);
        }
    }
}
