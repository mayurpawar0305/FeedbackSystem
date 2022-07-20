using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using DAL;

namespace BLL
{
    public class FeedbackManager
    {
        public static List<Student> GetAll ()
        {
            return StudentDAL.GetAll();
        }
        public static bool Insert(Student std)
        {
            return StudentDAL.Insert(std);
        }
        public static bool Update(Student stdTOUpdate)
        {
            return StudentDAL.Update(stdTOUpdate);
        }
        public static bool Delete(int feedbackid)
        {
            return StudentDAL.Delete(feedbackid);
        }
        public static Student GetByModule(string module)
        {
            return StudentDAL.GetByModule(module);
        }
    }
}
