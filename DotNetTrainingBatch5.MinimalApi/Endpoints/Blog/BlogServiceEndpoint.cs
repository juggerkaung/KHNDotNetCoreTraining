

using DotNetTrainingBatch5.Domain.Features.Blog;

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

            app.MapGet("/blogs", () =>
            {
                BlogService service = new BlogService();
                var lst = service.GetBlogs();
                return Results.Ok(lst);

            })
                .WithName("GetBlogs")
                .WithOpenApi();

            app.MapGet("/blogs/{id}", (int id) =>
            {

                AppDbContext db = new AppDbContext();

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



            app.MapPost("/blogs", (TblBlog blog) =>
            {
                AppDbContext db = new AppDbContext();
                db.TblBlogs.Add(blog);
                db.SaveChanges();
                return Results.Ok(blog);
            })
                .WithName("CreateBlog")
                .WithOpenApi();

            app.MapPut("/blogs/{id}", (int id, TblBlog blog) =>
            {
                AppDbContext db = new AppDbContext();
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

            app.MapDelete("/blogs/{id}", (int id) =>
            {
                AppDbContext db = new AppDbContext();

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
