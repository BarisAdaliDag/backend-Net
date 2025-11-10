using _34_AdoNET.Models;
using _34_AdoNET.Repo;
using Microsoft.Data.SqlClient;
using System.Data;

namespace _34_AdoNET
{
    internal class Program
    {
        //https://alkanfatih.com/veriye-erisim-ado-net/

        //https://www.connectionstrings.com/


        //connection string almak icin  SQL Server Object Exploer ac
        //ilgili database sag click properties lacal names
        //Data Source=(localdb)\ProjectModels;Initial Catalog=StudentDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False

       // Scaffold-DbContext "Data Source=(localdb)\ProjectModels;Initial Catalog=StudentDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models

        static void Main(string[] args)
        {
            string connectionString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=StudentDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            //#region DataAdapter

            //SqlConnection conn = new SqlConnection();
            //conn.ConnectionString = connectionString;

            //conn.Open();

            //SqlCommand cmd = new SqlCommand();
            //cmd.CommandText = "SELECT * FROM [Table] WHERE Age=@Age";
            //cmd.Parameters.AddWithValue("Age", 20);
            //cmd.Connection = conn;
            //cmd.CommandType = CommandType.Text;
            //SqlDataReader dr; //SQL Data Reader oluşturuldu.
            //dr = cmd.ExecuteReader(); //Command ile dönen veri SQLDataReader'a atanıyor.

            //if (dr.HasRows) //DataReader boş değilse.
            //{
            //    while (dr.Read()) //DataReader'ın okumaya devam ettiği sürece. 
            //    {
            //        Console.WriteLine(dr["Id"] + " " + dr["Name"] + " " + dr["Age"]);

            //    }
            //}
            //conn.Close();
            //#endregion
            //#region DataAdpter
            ////  SqlConnection conn = new SqlConnection();
            //conn.Open();
            ////SQL Data Adapter ile (Veritabanına komut gönderiyoruz.)
            //SqlDataAdapter adaptor = new SqlDataAdapter("SELECT * FROM [Table]", conn);
            //DataTable dt = new DataTable(); //DataTable oluşturuyoruz.
            //adaptor.Fill(dt); //Adaptor ile gelen veriyi DataTable taşıyoruz.

            //DataSet ds = new DataSet();
            //ds.Tables.Add(dt); //DataTable Set ile atama yaparak satırlar arasında dönüyoruz.

            //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //{
            //    Console.WriteLine(ds.Tables[0].Rows[i]["Name"] + " " + ds.Tables[0].Rows[i]["Age"].ToString());
            //}
            //#endregion

            IStudentRepo repo = new StudentRepo();
            while (true)
            {
                Console.WriteLine($"\n1. Listele \n2.Ekle \n3.Sil \n4.Guncelle \n 5.Cikis");
                string secim = Console.ReadLine();
                switch (secim)
                {

                    case "1":
                        foreach (var student in repo.GetAll())
                        {
                            Console.WriteLine(student);
                        }
                        break;
                    case "2":
                        Console.WriteLine("Adi:");
                        var name = Console.ReadLine();
                        Console.WriteLine("Age:");
                        var age = int.Parse(Console.ReadLine()) ;
                        repo.Add(new Student { Name = name, Age = age });
                        break;
                    case "3":
                        Console.WriteLine("Silinecek id ");
                        int id = int.Parse(Console.ReadLine());
                        repo.Delete(id);
                        break;
                            
                    case "4":
                        Console.WriteLine("Guncellenecek Id: ");
                        int updatedId = int.Parse(Console.ReadLine());
                        Console.WriteLine("Adi:");
                        var newName = Console.ReadLine();
                        Console.WriteLine("Age:");
                        var newAge = int.Parse(Console.ReadLine());
                        repo.Update(new Student { Id = updatedId, Name = newName, Age = newAge });
                        break;
                    default:
                        break;






                        //Entity
                        /*
                         
                         PM> Scaffold-DbContext "Data Source=(localdb)\\ProjectModels;Initial Catalog=StudentDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
                     
                         
                         PM> Scaffold-DbContext "Data Source=(localdb)\\ProjectModels;Initial Catalog=StudentDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False" Microsoft.EntityFrameworkCore.SqlServer
Build started..
                         */
                        // view>Other windos >package mangager

                }
            }
        }
    }
}