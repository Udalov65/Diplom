using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.ApplicationData
{
    internal class AppConnect
    {
        public static SibStroyEntities modelOdb { get; } = new SibStroyEntities();
        public static SibStroyEntities model0db;
    }
}
