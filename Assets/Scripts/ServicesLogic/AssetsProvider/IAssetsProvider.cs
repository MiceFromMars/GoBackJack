﻿using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using System;
using UnityEngine.AddressableAssets;
using UnityEngine;

namespace GBJ.ServicesLogic
{
    public interface IAssetsProvider : IService
    {
        void Initialize();
        UniTask<GameObject> Instantiate(string key, Vector3 pos);
        UniTask<GameObject> Instantiate(string key, RectTransform parent);
        UniTask<GameObject> Instantiate(string key);
        UniTask<T> Load<T>(AssetReference prefabReference) where T : class;
        UniTask<T> Load<T>(string address) where T : class;
        UniTask<IEnumerable<T>> LoadMultiple<T>(string key, Action<T> callback = null) where T : class;
        void ClearCache();
    }
}