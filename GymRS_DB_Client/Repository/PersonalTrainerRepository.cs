using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymRS_DB_DAL;

namespace GymRS_DB_Client
{
    public class PersonalTrainerRepository
    {

        public static void CriarPersonalTrainer()
        {
            var personalTrainer01 = new PersonalTrainer
            {
                PTCode = "PT001",
                Name = "Jorge Rodrigues"
            };

            var personalTrainer02 = new PersonalTrainer
            {
                PTCode = "PT002",
                Name = "Diogo Pinto"
            };

            var personalTrainer03 = new PersonalTrainer
            {
                PTCode = "PT003",
                Name = "Alberto Ferreira"
            };

            using (var context = new RSGymDBContext())
            {
                context.PersonalTrainer.Add(personalTrainer01);
                context.PersonalTrainer.Add(personalTrainer02);
                context.PersonalTrainer.Add(personalTrainer03);
                context.SaveChanges();
            }
        }

        internal static void CriarNovoPersonalTrainer()
        {
            using (var db = new RSGymDBContext())
            {
                Console.Write("\nCódigo do novo PT (PT***): ");
                var codigoPT = Console.ReadLine();

                var personalTrainer = new PersonalTrainer();

                Console.Write("Nome do novo PT: ");
                var nome = Console.ReadLine();

                var verificarExistencia = db.PersonalTrainer.FirstOrDefault(p => p.PTCode == personalTrainer.PTCode);

                if (verificarExistencia == null)
                {
                    personalTrainer.PTCode = codigoPT;
                    personalTrainer.Name = nome;
                    db.PersonalTrainer.Add(personalTrainer);

                    db.SaveChanges();
                    Console.WriteLine($"\nPersonal trainer com o codigo {codigoPT} e nome {nome} registado com sucesso!");
                    Console.ReadLine();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Já existe um Personal Trainer com esse código!");
                    CriarNovoPersonalTrainer();
                }

            }
        }

        internal static void ListarPT()
        {
            var db = new RSGymDBContext();

            var query = db.PersonalTrainer.Select(p => p).OrderBy(p => p.PTCode);

            Console.WriteLine("\n------------------------\nTODOS OS PTS\n------------------------");

            foreach (var item in query)
            {
                Console.WriteLine($"\nCódigo: {item.PTCode}\nNome: {item.Name}");
            }

            Console.ReadLine();

        }

        internal static void AtualizarPT()
        {

            using (var context = new RSGymDBContext())
            {
                Console.Write("\nCódigo do PT que quer atualizar: ");
                var codigoProcurado = Console.ReadLine();

                Console.Write("\nNovo nome: ");
                var novoNome = Console.ReadLine();

                var result = context.PersonalTrainer.SingleOrDefault(p => p.PTCode == codigoProcurado);


                if (result != null)
                {
                    result.Name = novoNome;
                    context.SaveChanges();
                    Console.WriteLine($"\nNome do PT com o código {codigoProcurado} atualizado para: {novoNome}");
                    Console.ReadLine();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Esse personal trainer não existe");
                 
                }


            }

        }

    }
}
