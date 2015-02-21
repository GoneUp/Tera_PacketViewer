using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Structures.Npc;

namespace Communication.Interfaces
{
    public interface INpcService : IComponent
    {
        void GetNpcActionType(Npc npc);
    }
}
