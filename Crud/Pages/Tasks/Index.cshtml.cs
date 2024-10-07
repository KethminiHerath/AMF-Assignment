using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Net.Security;

namespace Crud.Pages.Tasks
{
    public class IndexModel : PageModel
    {
        public List<TaskInfo> listTasks = new List<TaskInfo>();
        public void OnGet()
        {
            try
            {
                String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=TaskManager;Integrated Security=True;Trust Server Certificate=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM tasks";
                    using (SqlCommand command = new SqlCommand(sql, connection)) {

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read()) {
                            
                                TaskInfo taskInfo = new TaskInfo();
                                taskInfo.id = "" + reader.GetInt32(0);
                                taskInfo.title = "" + reader.GetInt32(0);
                                taskInfo.description = "" + reader.GetInt32(0);

                                listTasks.Add(taskInfo);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception" +ex.ToString());
            }
        }
    }

    public class TaskInfo {

        public string id;
        public string title;
        public string description;
    }
    
}
