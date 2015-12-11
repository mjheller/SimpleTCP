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

        
        public T data{ get; set; }

        public Data(T data)
        {
            this.data = data;
        }


        //public override string ToString()
        //{
        //    return base.ToString();
        //}
    }
}
