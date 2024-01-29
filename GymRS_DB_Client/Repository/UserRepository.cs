using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymRS_DB_DAL;


namespace GymRS_DB_Client
{
    public class UserRepository
    {

        public static void CriarUser()
        {

            var user01 = new User
            {
                Username = "diogop164",
                Password = "123abc"
            };

            var user02 = new User
            {
                Username = "joao111",
                Password = "11111"
            };

            using (var context = new RSGymDBContext())
            {
                context.User.Add(user01);
                context.User.Add(user02);
                context.SaveChanges();
            }

        }



    }
}
