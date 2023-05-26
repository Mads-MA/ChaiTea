using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;


namespace ChaiTea
{
    public class Util 
    {
        public delegate void DebugCallback([MarshalAs(UnmanagedType.LPStr)]string msg, int severity);
        [DllImport("ChaiTeaLib", EntryPoint = "Util_RegisterLogCallback")]
        public static extern void RegisterLogCallback(DebugCallback cb);
    }
}
