using BlazorAppWithIdentity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazorAppWithIdentity.Contexts;
public class AppDbContext(DbContextOptions<AppDbContext> options) :
    IdentityDbContext<User>(options)
{
}