using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Codestellation.Ether.Core;

namespace Codestellation.Ether.Persistence
{
    public interface IRepository
    {
        void Save(Email[] emails);
        Email[] Load();
    }
}