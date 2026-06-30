using Refit;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetTraininngBatch5.ConsoleApp3
{
    public class RefitExample
    {
         public async Task Run()
        {
            var blogApi = RestService.For<IBlogApi>("https://localhost:7091");
            var lst = await blogApi.GetBlogs();
            foreach(var item in lst)
            {
                Console.WriteLine(item.BlogTitle);
            }

            var item2 = blogApi.GetBlog(1);
            try
            {
                var item3 = blogApi.GetBlog(100);
            }
            catch(ApiException ex)
            {
                if(ex.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    Console.WriteLine("No data found");
                }
            }

            var item4 = await blogApi.CreateBlog(new BlogModel
            {
                BlogTitle = "test",
                BlogAuthor = "test",
                BlogContent = "test"
            });

        }
    }
}
