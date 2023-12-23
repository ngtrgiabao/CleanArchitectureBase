namespace Core.Models
{
    public class ResponseModel
    {
        public string Status { get; set; }
        public object Result { get; set; }
        public ResponseModel() { }
        public ResponseModel(string status, object data)
        {
            Status = status;
            Result = data;
        }
    }


}
