using UnityEngine;

namespace Patterns.Adapter
{
    public class Consumer : MonoBehaviour
    {
        private IDataStore _dataStore;

        private void Awake()
        {
            _dataStore = GetDataStore();

            var data = new Data("Data1", 123);
            _dataStore.SetData(data, "Data1");
        }

        private IDataStore GetDataStore()
        {
            // return new PlayerPrefsDataStoreAdapter();
            return new FileDataStoreAdapter();
        }

        private void Start()
        {
            var data = _dataStore.GetData<Data>("Data1");
            Debug.Log(data.dato1);
            Debug.Log(data.dato2);
        }
    }
}
