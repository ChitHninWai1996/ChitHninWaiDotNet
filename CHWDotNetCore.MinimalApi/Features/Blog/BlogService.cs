﻿using CHWDotNetCore.MinimalApi.Db;
using Microsoft.EntityFrameworkCore;
using CHWDotNetCore.MinimalApi.Models;

namespace CHWDotNetCore.MinimalApi.Features.Blog
{
    public static class BlogService
    {
        public static IEndpointRouteBuilder AddBlogFeatures(this IEndpointRouteBuilder app)
        {
            app.MapGet("api/Blog", async (AppDbContext db) =>
            {
                var lst = await db.Blogs.AsNoTracking().ToListAsync();
                return Results.Ok(lst);
            });

            app.MapPost("api/Blog", async (AppDbContext db, BlogModel blog) =>
            {
                await db.Blogs.AddAsync(blog);
                var result = await db.SaveChangesAsync();

                string message = result > 0 ? "Saving Successful." : "Saving Failed.";
                return Results.Ok(message);
            });

            app.MapPut("api/Blog/{id}", async (AppDbContext db, int id, BlogModel blog) =>
            {
                var item = await db.Blogs.FirstOrDefaultAsync(x => x.BlogId == id);
                if (item is null)
                {
                    return Results.NotFound("No data foud");
                }

                item.BlogTitle = blog.BlogTitle;
                item.BlogAuthor = blog.BlogAuthor;
                item.BlogContent = blog.BlogContent;
                var result = await db.SaveChangesAsync();

                string message = result > 0 ? "Updating Successful." : "Updating Failed.";
                return Results.Ok(message);
            });

            app.MapPut("api/Blog/{id}", async (AppDbContext db, int id) =>
            {
                var item = await db.Blogs.FirstOrDefaultAsync(x => x.BlogId == id);
                if (item is null)
                {
                    return Results.NotFound("No data foud");
                }

                db.Blogs.Remove(item);
                var result = await db.SaveChangesAsync();

                string message = result > 0 ? "Deleting Successful." : "Deleting Failed.";
                return Results.Ok(message);
            });

            return app;
        }
    }
}
