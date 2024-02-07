using HMS.Library.Models;

namespace HMS.Api.ModelsData
{
    public class DoctorData : Doctor
    {
        public IFormFile ImageUpload { get; set; }
    }
}
