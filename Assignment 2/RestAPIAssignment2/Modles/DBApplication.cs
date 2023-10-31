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

                    product.product_name = (string)dt.Rows[i]["product_name"];
                    product.product_id = (int)dt.Rows[i]["product_id"];
                    product.product_amount = (double)dt.Rows[i]["product_amount"];
                    product.product_price = (double)dt.Rows[i]["product_price"];
                    product.product_date = (string)dt.Rows[i]["product_date"];

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
                product.product_id = (int)dt.Rows[0]["product_id"];
                product.product_name = (string)dt.Rows[0]["product_name"];
                product.product_amount = (double)dt.Rows[0]["product_amount"];
                product.product_price = (double)dt.Rows[0]["product_price"];
                product.product_date = (string)dt.Rows[0]["product_date"];

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
            string Query = "insert into products values(@product_name, default, @product_amount, " +
                "@product_price, @product_date)";
            NpgsqlCommand cmd = new NpgsqlCommand(Query, con);
            cmd.Parameters.AddWithValue("@product_name", product.product_name);
            cmd.Parameters.AddWithValue("@product_amount", product.product_amount);
            cmd.Parameters.AddWithValue("@product_price", product.product_price);
            cmd.Parameters.AddWithValue("@product_date", product.product_date);

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
            string Query = "Update products set product_name=@name, product_amount=@amount" +
                ", product_price=@price, product_date=@year where product_id=@ID";
            NpgsqlCommand cmd = new NpgsqlCommand(Query, con);
            cmd.Parameters.AddWithValue("@name", product.product_name);
            cmd.Parameters.AddWithValue("@amount", product.product_amount);
            cmd.Parameters.AddWithValue("@price", product.product_price);
            cmd.Parameters.AddWithValue("@year", product.product_date);
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
            string Query = "Delete from products where product_id='" + id + "'";
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
