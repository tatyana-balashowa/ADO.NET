using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Entities;

namespace Users.BLL
{
    public interface IAwardLogic
    {
        IEnumerable<Award> GetAwardsByUser(int index);
        IEnumerable<Award> GetNeedAwards(int indexUser, string Title);
        void AddAward(int indexUser, string Title);
        void RemoveAward(int indexUser, string Title);
    }
}
