using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CRUD_Operations_in_WebAPI.Models;
using System.Data.SqlClient;

namespace CRUD_Operations_in_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CRUDOperationsController : ControllerBase
    {
        private readonly string connectionString;

        public CRUDOperationsController(IConfiguration configuration)
        {
            connectionString = configuration["ConnectionStrings:SqlServerDb"] ?? "";
        }

        [HttpPost]
        public IActionResult CreateOperation(CRUDOperationsModel cRUDOperationsModel)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "INSERT INTO SAMPLE" + "(Column1 ,Column2 ,Column3 ,Column4) VALUES" +
                                 "(@Column1, @Column2, @Column3, @Column4)";

                    using (var command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Column1", cRUDOperationsModel.Column1);
                        command.Parameters.AddWithValue("@Column2", cRUDOperationsModel.Column2);
                        command.Parameters.AddWithValue("@Column3", cRUDOperationsModel.Column3);
                        command.Parameters.AddWithValue("@Column4", cRUDOperationsModel.Column4);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Sample", "Sorry we have an exception");
                return BadRequest(ModelState);
            }

            return Ok();
        }
        [HttpGet]
        public IActionResult ReadOperation()
        {
            List<Sample> sample = new List<Sample>();

            try
            {
                using var connection = new SqlConnection(connectionString);
                {
                    connection.Open();

                    string sql = "SELECT * FROM SAMPLE";
                    using (var command = new SqlCommand(sql, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Sample samples = new Sample();

                                samples.id = reader.GetInt32(0);
                                samples.Column1 = reader.GetString(1);
                                samples.Column2 = reader.GetDecimal(2);
                                samples.Column3 = reader.GetDateTime(3);
                                samples.Column4 = reader.GetString(4);
                                samples.Create_Date = reader.GetDateTime(5);

                                sample.Add(samples);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Sample", "Sorry we have an exception");
                return BadRequest(ModelState);
            }
            return Ok(sample);
        }

        [HttpGet("{id}")]
        public IActionResult ReadOperationbyId(int id)
        {
            Sample samples = new Sample();

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();


                    string sql = "SELECT * FROM SAMPLE Where id=@id";
                    using (var command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                samples.id = reader.GetInt32(0);
                                samples.Column1 = reader.GetString(1);
                                samples.Column2 = reader.GetDecimal(2);
                                samples.Column3 = reader.GetDateTime(3);
                                samples.Column4 = reader.GetString(4);
                                samples.Create_Date = reader.GetDateTime(5);
                            }
                            else
                            {
                                return NotFound("Not Found");
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Sample", "Sorry we have an exception");
                return BadRequest(ModelState);
            }
            return Ok(samples);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOperation(int id, CRUDOperationsModel cRUDOperationsModel)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "UPDATE SAMPLE SET Column1=@Column1, Column2=@Column2, " +
                                 "Column3=@Column3, Column4=@Column4 WHERE id=@id";

                    using (var command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Column1", cRUDOperationsModel.Column1);
                        command.Parameters.AddWithValue("@Column2", cRUDOperationsModel.Column2);
                        command.Parameters.AddWithValue("@Column3", cRUDOperationsModel.Column3);
                        command.Parameters.AddWithValue("@Column4", cRUDOperationsModel.Column4);
                        command.Parameters.AddWithValue("@id", id);

                        command.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Sample", "Sorry we have an exception");
                return BadRequest(ModelState);
            }

            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteOperation(int id)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "DELETE FROM SAMPLE where id=@id";
                    using (var command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id",id);

                        command.ExecuteNonQuery ();
                    }
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Sample", "Sorry we have an exception");
                return BadRequest(ModelState);
            }
            return Ok();
        }
    }
}
