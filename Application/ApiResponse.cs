using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class ApiResponse<T>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public T Data { get; set; }
        public string Error { get; set; }

        public ApiResponse(int id, string title, T data, string error)
        {
            Id = id;
            Title = title;
            Data = data;
            Error = error;
        }
    }
}
