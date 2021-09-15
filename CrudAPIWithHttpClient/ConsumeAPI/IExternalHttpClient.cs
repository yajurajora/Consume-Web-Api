using CrudAPIWithHttpClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAPIWithHttpClient.ConsumeAPI
{
    public interface IExternalHttpClient
    {
        List<Student> GetExternalAsync(List<Student> data,string url);
        Student PostExternalAsync(Student student, string url);
        Student PutExternalAsyncGet(int id,string url);
        Student PutExternalAsync(Student student, string url);
        Student DeleteExternalAsync(Student student, string url,int id);
    }
}
