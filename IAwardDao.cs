using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Entities;

namespace Users.DAL
{
    public interface IAwardDao
    {
        IEnumerable<Award> GetAwards(int index);
        IEnumerable<Award> GetNeedAwards(int indexUser, string Title);
        void AddAward(int index, string Title);
        void RemoveAward(int indexUser, string Title);

    }
}
