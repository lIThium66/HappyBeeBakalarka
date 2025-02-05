using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using VersionOneWA.Components.Account;
using VersionOneWA.Data;
using VersionOneWA.Shared.Classes;


internal sealed class UserAccesor(
        IHttpContextAccessor httpContextAccessor,
        UserManager<ApplicationUser> userManager,
        IdentityRedirectManager redirectManager)
    {

        public async Task<ApplicationUser> GetRequiredUserAsync()
        {
            
            var principal = httpContextAccessor.HttpContext?.User
                            ?? throw new InvalidOperationException(
                                $"{nameof(GetRequiredUserAsync)} vyžaduje prístup k {nameof(HttpContext)}.");

            // Načítanie používateľa cez UserManager
            var user = await userManager.GetUserAsync(principal);

            // Ak používateľ neexistuje, presmerovanie na chybu
            if (user is null)
            {
            
                redirectManager.RedirectToWithStatus(
                    "/Account/InvalidUser",
                    "Error: Unable to load user with the given identity.", httpContextAccessor.HttpContext
                );
            }

            return user;
        }
    }

