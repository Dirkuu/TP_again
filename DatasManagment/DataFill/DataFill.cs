using System;
using System.Collections.Generic;
using System.Text;

namespace DatasManagment

{
    public interface DataFill
    {
        void Fill(ref DataContext dataContext);
    }
}
