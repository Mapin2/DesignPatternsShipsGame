using System;

namespace Patterns.Adapter
{
    [Serializable]
    public class Data
    {
        public string dato1;
        public int dato2;

        public Data(string dato1, int dato2)
        {
            this.dato1 = dato1;
            this.dato2 = dato2;
        }
    }
}
