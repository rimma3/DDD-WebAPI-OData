using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR.CreativeAPI.Core.Data
{
    public interface IUpdatable
    {
        int UpdateUserId { get; set; }

        DateTime UpdateDT { get; set; }

    }
}
