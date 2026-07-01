

using DotNetTrainingBatch5.Domain.Features.Blog;
using Microsoft.AspNetCore.Mvc;

namespace DotNetTrainingBatch5.MinimalApi.Endpoints.Blog
{
    // put static here to use 'this'
    public static class BlogServiceEndpoint
    {
        // 'this' keyword:
        // that parameter move forward/front and instead of using this class in other file:
        // BlogEndpoints.Test(9);
        // Can use like this:
        // 9.Test();
        //public static string Test(this int i)
        //{
        //    return i.ToString();
        //}
    // ---

        public static void UseBlogServiceEndpoint(this IEndpointRouteBuilder app)
        {

            app.MapGet("/blogs", ([FromServices] IBlogService service) =>
            {
                var lst = service.GetBlogs();
                return Results.Ok(lst);

            })
                .WithName("GetBlogs")
                .WithOpenApi();

            app.MapGet("/blogs/{id}", ([FromServices] AppDbContext db, int id) =>
            {
                var item = db.TblBlogs
                .AsNoTracking()
                .FirstOrDefault(x => x.BlogId == id);
                if (item is null)
                {
                    return Results.BadRequest("No data found.");
                }
                return Results.Ok(item);

            })
                .WithName("GetBlog")
                .WithOpenApi();



            app.MapPost("/blogs", ([FromServices] AppDbContext db, TblBlog blog) =>
            {
                db.TblBlogs.Add(blog);
                db.SaveChanges();
                return Results.Ok(blog);
            })
                .WithName("CreateBlog")
                .WithOpenApi();

            app.MapPut("/blogs/{id}", ([FromServices] AppDbContext db, int id, TblBlog blog) =>
            {
                // Note: if used AsNoTracking in here then the SaveChanges will not work.
                // but if added AsNoTracking then add this line:
                // db.Entry(item).State = EntryState.Modified;
                var item = db.TblBlogs
                .AsNoTracking()
                .FirstOrDefault(x => x.BlogId == id);
                if (item is null)
                {
                    return Results.BadRequest("No data found.");
                }

                item.BlogTitle = blog.BlogTitle;
                item.BlogAuthor = blog.BlogAuthor;
                item.BlogContent = blog.BlogContent;

                db.Entry(item).State = EntityState.Modified;

                db.SaveChanges();
                return Results.Ok(blog);
            })
                  .WithName("UpdateBlog")
                .WithOpenApi();

            app.MapDelete("/blogs/{id}", ([FromServices] AppDbContext db, int id) =>
            {
                var item = db.TblBlogs
                .AsNoTracking()
                .FirstOrDefault(x => x.BlogId == id);
                if (item is null)
                {
                    return Results.BadRequest("No data found.");
                }

                db.Entry(item).State = EntityState.Deleted;

                db.SaveChanges();
                return Results.Ok();
            })
              .WithName("DeleteBlog")
                .WithOpenApi();


        }
    
    }
}
