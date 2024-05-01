using System.Data.SqlClient;
using Project3.model;

namespace Project3.repositories;

public class AnimalsRepository : IAnimalsRepository
{
    private IConfiguration _configuration;

    public AnimalsRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public IEnumerable<Animal> GetAnimals()
    {
        using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        con.Open();

        using var query = new SqlCommand();
        query.Connection = con;
        query.CommandText = "SELECT IdAnimal, Name, Description, Category, Area FROM Animal";

        var dr = query.ExecuteReader();
        var animals = new List<Animal>();

        while (dr.Read())
        {
            var desc = dr["Description"];
            if (desc == null)
            {
                desc = "";
            }
            var receivedAnimal = new Animal(
                (int)dr["IdAnimal"], 
                dr["Name"].ToString(), 
                desc.ToString(), 
                dr["Category"].ToString(), 
                dr["Area"].ToString()
                );
            animals.Add(receivedAnimal);
        }

        return animals;
    }

    public int CreateAnimal(Animal animal)
    {
        using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        con.Open();

        using var query = new SqlCommand();
        query.Connection = con;
        query.CommandText =
            "INSERT INTO Animal(Name, Description,Category, Area) VALUES(@Name, @Description, @Category, @Area)";
        query.Parameters.AddWithValue("@IdAnimal", animal.IdAnimal);
        query.Parameters.AddWithValue("@Name", animal.Name);
        query.Parameters.AddWithValue("@Description", animal.Description);
        query.Parameters.AddWithValue("@Category", animal.Category);
        query.Parameters.AddWithValue("@Area", animal.Area);

        var count = query.ExecuteNonQuery();
        return count;
    }

    public Animal GetAnimal(int animalId)
    {
        using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        con.Open();

        using var query = new SqlCommand();
        query.Connection = con;
        query.CommandText = "SELECT IdAnimal, Name, Description, Category, Area FROM Animal WHERE IdAnimal = @IdAnimal";
        query.Parameters.AddWithValue("@IdAnimal", animalId);
        
        var dr = query.ExecuteReader();

        if (!dr.Read()) return null;
        
        var desc = dr["Description"];
        if (desc == null)
        {
            desc = "";
        }
        var receivedAnimal = new Animal(
            (int)dr["IdAnimal"], 
            dr["Name"].ToString(), 
            desc.ToString(), 
            dr["Category"].ToString(), 
            dr["Area"].ToString()
        );
    

        return receivedAnimal;
    }

    public int UpdateAnimal(Animal animal)
    {
        using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        con.Open();
        
        using var query = new SqlCommand();
        query.Connection = con;
        query.CommandText = "UPDATE Animal SET Name=@Name, Description=@Description, Category=@Category, Area=@Area WHERE IdAnimal = @IdAnimal";
        query.Parameters.AddWithValue("@IdAnimal", animal.IdAnimal);
        query.Parameters.AddWithValue("@Name", animal.Name);
        query.Parameters.AddWithValue("@Description", animal.Description);
        query.Parameters.AddWithValue("@Category", animal.Category);
        query.Parameters.AddWithValue("@Area", animal.Area);

        var count = query.ExecuteNonQuery();
        return count;
    }

    public int DeleteAnimal(int animalId)
    {
        using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        con.Open();

        using var query = new SqlCommand();
        query.Connection = con;
        query.CommandText = "DELETE FROM Animal WHERE IdAnimal = @IdAnimal";
        query.Parameters.AddWithValue("@IdAnimal", animalId);

        var count = query.ExecuteNonQuery();
        return count;
    }
}