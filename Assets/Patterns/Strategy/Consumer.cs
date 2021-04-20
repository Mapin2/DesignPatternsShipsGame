using Patterns.Adapter;
using UnityEngine;

namespace Patterns.Strategy
{
    public class Consumer
    {
        private readonly IDataStore _dataStore;

        public Consumer(IDataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public void Save()
        {
            var data = new Data("Hola", 4545);
            _dataStore.SetData(data, "Data2");
        }

        public void Load()
        {
            var data = _dataStore.GetData<Data>("Data2");
            Debug.Log(data.dato1);
            Debug.Log(data.dato2);
        }
    }
}