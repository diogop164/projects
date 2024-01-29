using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymRS_DB_DAL;

namespace GymRS_DB_Client
{
    class Program
    {
        static void Main(string[] args)
        {

            UserRepository.CriarUser();
            PersonalTrainerRepository.CriarPersonalTrainer();
            RequestStatusRepository.CriarStatus();


            GymRS.IniciarApp();
            GymRS.EfetuarLogin();
        }
    }
}
