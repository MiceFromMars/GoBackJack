using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace GBJ.ServicesLogic
{
    public sealed class AssetsProvider : IAssetsProvider
    {
        private readonly Dictionary<string, AsyncOperationHandle> _completedHandles = new();
        private readonly Dictionary<string, List<AsyncOperationHandle>> _handles = new();

        public void Initialize()
        {
            Addressables.InitializeAsync();
        }

        #region Instantiation

        public UniTask<GameObject> Instantiate(string key, Vector3 pos)
        {
            return Addressables.InstantiateAsync(key, pos, Quaternion.identity).ToUniTask();
        }

        public UniTask<GameObject> Instantiate(string key, RectTransform parent)
        {
            return Addressables.InstantiateAsync(key, parent).ToUniTask();
        }

        public UniTask<GameObject> Instantiate(string key)
        {
            return Addressables.InstantiateAsync(key).ToUniTask();
        }

        #endregion

        #region Loading

        public async UniTask<T> Load<T>(AssetReference assetReference) where T : class
        {
            if (_completedHandles.TryGetValue(assetReference.AssetGUID, out AsyncOperationHandle completedHandle))
            {
                return completedHandle.Result as T;
            }
            else
            {
                var handle = await RunAndCacheOnComplete(Addressables.LoadAssetAsync<T>(assetReference), assetReference.AssetGUID);
                return handle;
            }
        }

        public async UniTask<T> Load<T>(string key) where T : class
        {
            if (_completedHandles.TryGetValue(key, out AsyncOperationHandle completedHandle))
            {
                return completedHandle.Result as T;
            }
            else
            {
                var handle = await RunAndCacheOnComplete(Addressables.LoadAssetAsync<T>(key), key);
                return handle;
            }
        }

        public async UniTask<IEnumerable<T>> LoadMultiple<T>(string key, Action<T> callback = null) where T : class
        {
            if (_completedHandles.TryGetValue(key, out AsyncOperationHandle completedHandle))
            {
                return completedHandle.Result as IEnumerable<T>;
            }
            else
            {
                var handle = await RunAndCacheOnComplete(Addressables.LoadAssetsAsync(key, callback), key);
                return handle;
            }
        }

        #endregion

        #region Internal

        private async UniTask<T> RunAndCacheOnComplete<T>(AsyncOperationHandle<T> handle, string cacheKey) where T : class
        {
            handle.Completed += completeHandle =>
            {
                _completedHandles[cacheKey] = completeHandle;
                _handles.Remove(cacheKey);
            };

            AddHandle<T>(cacheKey, handle);

            return await handle.ToUniTask();
        }

        private void AddHandle<T>(string cacheKey, AsyncOperationHandle handle) where T : class
        {
            if (!_handles.TryGetValue(cacheKey, out List<AsyncOperationHandle> resourceHandles))
            {
                resourceHandles = new List<AsyncOperationHandle>();
                _handles[cacheKey] = resourceHandles;
            }

            resourceHandles.Add(handle);
        }

        #endregion

        public void ClearCache()
        {
            foreach (List<AsyncOperationHandle> resourceHandles in _handles.Values)
            {
                foreach (AsyncOperationHandle handle in resourceHandles)
                {
                    Addressables.Release(handle);
                }
            }
            _handles.Clear();

            foreach (AsyncOperationHandle handle in _completedHandles.Values)
            {
                 Addressables.Release(handle);
            }
            _completedHandles.Clear();
        }
    }
}