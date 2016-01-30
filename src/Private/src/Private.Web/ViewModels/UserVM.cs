using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Private.Web.ViewModels
{
    public class UserVm
    {
        
        public event Func<Task> Creating;

        public async Task Create()
        {
            await Creating();
        }
    }
}
