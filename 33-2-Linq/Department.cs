namespace _33_2_Linq
{
    public class Department 
    {
    public int Id { get; set;}
    public string Name { get; set; }

        // ToString metodu eklendi
        public override string ToString()
        {
            return $"ID: {Id}, Departman: {Name}";
        }


    }

}
