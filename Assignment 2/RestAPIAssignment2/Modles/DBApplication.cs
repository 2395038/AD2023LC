using Npgsql;
using System.Data;
using System.Security.Cryptography;


namespace RestAPIAssignment2.Modles
{
    public class DBApplication
    {
        public Response GetAllProducts(NpgsqlConnection con)
        {
            string Query = "Select * from products";

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(Query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            Response response = new Response();

            List<Product> products = new List<Product>();

            if (dt.Rows.Count > 0)  
            {
                
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Product product = new Product();

                    product.product_name = (string)dt.Rows[i]["Product_Name"];
                    product.product_id = (int)dt.Rows[i]["Product_ID"];
                    product.product_amount = (double)dt.Rows[i]["Amount"];
                    product.product_price = (double)dt.Rows[i]["Price"];
                   

                    products.Add(product);
                }
            }

            if (products.Count > 0)
            {
                response.statusCode = 200;
                response.messageCode = "Data Retrieved Successfully";
                response.product = null;
                response.products = products;
            }
            else
            {
                response.statusCode = 100;
                response.messageCode = "Data failed to Retrieve or maybe table is empty";
                response.product = null;
                response.products = null;
            }
            return response;
        }

        public Response GetProductbyId(NpgsqlConnection con, int id)
        {
            
            Response response = new Response();
           
            string Query = "Select * from products where product_id='" + id + "'"; 

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(Query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0) 
            {
                Product product = new Product();
                product.product_name = (string)dt.Rows[0]["Product_Name"];
                product.product_id = (int)dt.Rows[0]["Product_ID"];
                product.product_amount = (double)dt.Rows[0]["Amount"];
                product.product_price = (double)dt.Rows[0]["Price"];


                response.statusCode = 200;
                response.messageCode = "Successfully Retrieved";
                response.product = product;
                response.products = null;
            }
            else
            {
                response.statusCode = 100;
                response.messageCode = "Data couldn't found ... check the id";
                response.product = null;
                response.products = null;
            }
            return response;
        }

        public Response AddProduct(NpgsqlConnection con, Product product)
        {
            con.Open();
            Response response = new Response();
            string Query = "insert into products values(@Product_Name, @Product_ID, @Amount, " +
                "@Price)";
            NpgsqlCommand cmd = new NpgsqlCommand(Query, con);
            cmd.Parameters.AddWithValue("@Product_Name", product.product_name);
            cmd.Parameters.AddWithValue("@Product_ID", product.product_id);
            cmd.Parameters.AddWithValue("@Amount", product.product_amount);
            cmd.Parameters.AddWithValue("@Price", product.product_price);
           

            int i = cmd.ExecuteNonQuery();

            if (i > 0) 
            {
                response.statusCode = 200;
                response.messageCode = "Successfully inserted";
                response.product = product;
                response.products = null;
            }
            else
            {
                response.statusCode = 100;
                response.messageCode = "Insertion is not successfull";
                response.product = null;
                response.products = null;
            }
            con.Close();
            return response;
        }

        public Response UpdateProduct(NpgsqlConnection con, Product product)
        {
            con.Open();
            Response response = new Response();
            string Query = "Update products Set Product_Name=@name, Amount=@amount" +
                ", Price=@price where Product_ID=@ID";
            NpgsqlCommand cmd = new NpgsqlCommand(Query, con);
            cmd.Parameters.AddWithValue("@name", product.product_name);
            cmd.Parameters.AddWithValue("@amount", product.product_amount);
            cmd.Parameters.AddWithValue("@price", product.product_price);
            cmd.Parameters.AddWithValue("@ID", product.product_id);

            int i = cmd.ExecuteNonQuery();

            if (i > 0)
            {
                response.statusCode = 200;
                response.messageCode = "Updated Successfully";
                response.product = product;
            }
            else
            {
                response.statusCode = 100;
                response.messageCode = "Update failed or id wasn't in correct form";
            }
            con.Close();
            return response;
        }

        public Response DeleteProductbyId(NpgsqlConnection con, int id)
        {
            con.Open();
            Response response = new Response();
            string Query = "Delete from products where Product_ID='" + id + "'";
            NpgsqlCommand cmd = new NpgsqlCommand(Query, con);

            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                response.statusCode = 200;
                response.messageCode = "Product Delected Successfully";
            }
            else
            {
                response.statusCode = 100;
                response.messageCode = "Product not found. Could not perform delete Ops";
            }
            con.Close();
            return response;
        }

    }
}
