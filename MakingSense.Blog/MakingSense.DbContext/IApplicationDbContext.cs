using Microsoft.EntityFrameworkCore;
using System;

namespace MakingSense.DataContext
{
    public interface IApplicationDbContext: IDisposable
    {
        DbSet<Model.User> Users{ get; }
        DbSet<Model.Post> Posts { get; }
        

    }
}
