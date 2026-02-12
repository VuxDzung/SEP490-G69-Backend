namespace Backend_Test_DynamoDB.Models
{
    public class Package
    {
        public string PackageId { get; set; }
        public string PackageName { get; set; }
        public string PackageDesc { get; set; }
        public float UsdPrice { get; set; }
        public float VndPrice { get; set; }
    }
}
