using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR.CreativeAPI.Core.Data
{
    public interface IInsertable
    {
        int InsertUserId { get; set; }

        DateTime InsertDT { get; set; }
    }
}
