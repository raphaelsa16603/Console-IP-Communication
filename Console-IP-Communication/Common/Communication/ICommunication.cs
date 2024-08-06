using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Communication
{
    public interface ICommunication
    {
        void Start();
        void Send<T>(T data);
        T Receive<T>();
    }
}

