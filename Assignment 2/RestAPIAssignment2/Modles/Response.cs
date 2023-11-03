namespace RestAPIAssignment2.Modles
{
    public class Response
    {
        public int statusCode { get; set; }

        // response has a message
        public string messageCode { get; set; }

        // response can have only one student retrive from the databse
        public Product product { get; set; }

        // response can have list of students from the database
        public List<Product> products { get; set; }

       // public Response() { }
    }
}
