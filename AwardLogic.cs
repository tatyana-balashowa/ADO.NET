using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Entities;
using Users.DAL;
namespace Users.BLL
{
    public class AwardLogic:IAwardLogic
    {
        private IAwardDao awardDao;
        public AwardLogic ()
        {
            awardDao = new AwardDaoDB();
        }
        public IEnumerable<Award> GetAwardsByUser(int index)
        {
            return awardDao.GetAwards(index);
        }
        public IEnumerable<Award> GetNeedAwards(int indexUser, string Title)
        {
            return awardDao.GetNeedAwards(indexUser,Title); 
        }
        public void AddAward(int indexUser, string Title)
        {
            awardDao.AddAward(indexUser, Title);
        }
        public void RemoveAward (int indexUser, string Title)
        {
            awardDao.RemoveAward(indexUser, Title);
        }
    }
}
