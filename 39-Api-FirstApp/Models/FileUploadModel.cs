namespace _39_Api_FirstApp.Models
{
    public class FileUploadModel
    {
        public string Description { get; set; }
        public IFormFile File { get; set; }//formdaki dosya alani 
    }
}
