using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTCP
{
    [Serializable]
    public class Data<T>
    {

        T message;
        public T Message { get; set; }


        
        public Data(T data)
        {
            this.message = data;
        }


        public override string ToString()
        {
            return base.ToString();
        }
    }
}
